using EpamNUnit1.Helpers;
using ApiTest.Models;
using EpamNUnit1.Tests;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTest.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ApiTests : BaseApiTests
{
    [Test]
    public void GetUsers_FieldsExistTest()
    {
        RestRequest restRequest = new RestRequest("users", Method.Get);
        RestResponse restResponse = _restClient.Execute(restRequest);

        Logger.LogInfo<ApiTests>($"Request resource {restRequest.Resource} {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        string? json = restResponse.Content;

        Assert.That(json, Is.Not.Null.And.Not.Empty);

        JArray jArray = JArray.Parse(json);

        foreach (JObject jObject in jArray)
        {
            Assert.That(jObject.ContainsKey("id"), Is.True);
            Assert.That(jObject.ContainsKey("name"), Is.True);
            Assert.That(jObject.ContainsKey("username"), Is.True);
            Assert.That(jObject.ContainsKey("email"), Is.True);
            Assert.That(jObject.ContainsKey("address"), Is.True);
            Assert.That(jObject.ContainsKey("phone"), Is.True);
            Assert.That(jObject.ContainsKey("website"), Is.True);
            Assert.That(jObject.ContainsKey("company"), Is.True);
        }
    }

    [Test]
    public void GetUsers_CorrectHeader()
    {
        RestRequest restRequest = new RestRequest("users", Method.Get);
        RestResponse restResponse = _restClient.Execute(restRequest);

        Logger.LogInfo<ApiTests>($"Request resource {restRequest.Resource} {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(restResponse.ContentType, Is.EqualTo("application/json"));
    }

    [Test]
    public void GetUsers_FieldsAreCorrectTest()
    {

        RestRequest restRequest = new RestRequest("users", Method.Get);
        RestResponse<UserModel[]> restResponse = _restClient.Execute<UserModel[]>(restRequest);

        Logger.LogInfo<ApiTests>($"Request resource {restRequest.Resource} {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        UserModel[]? users = restResponse.Data;

        Assert.That(users, Is.Not.Null);
        Assert.That(users.Length, Is.EqualTo(10));

        for (int i = 0; i < users.Length; i++)
        {
            for (int j = 0; j < users.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                Assert.That(users[i].Id, Is.Not.EqualTo(users[j].Id));
            }

        }

        foreach (UserModel user in users)
        {
            Assert.That(user.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(user.UserName, Is.Not.Null.And.Not.Empty);
            Assert.That(user.Company, Is.Not.Null);
            Assert.That(user.Company.Name, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test]
    public void CreateUser_ContainsIdTest()
    {
        RestRequest restRequest = new RestRequest("users", Method.Post);
        RestResponse<UserCreatedModel> restResponse = _restClient.Execute<UserCreatedModel>(restRequest);

        Logger.LogInfo<ApiTests>($"Request resource {restRequest.Resource} {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        UserCreatedModel? user = restResponse.Data;

        Assert.That(user, Is.Not.Null);
        Assert.That(user.Id, Is.AtLeast(1));
    }

    [Test]
    public void InvalidEndpoint_NotFoundTest()
    {
        RestRequest restRequest = new RestRequest("invalidendpoint", Method.Get);
        RestResponse restResponse = _restClient.Execute(restRequest);

        Logger.LogInfo<ApiTests>($"Request resource {restRequest.Resource} {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}