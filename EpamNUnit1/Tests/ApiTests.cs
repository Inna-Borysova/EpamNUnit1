using EpamNUnit1.Helpers;
using ApiTest.Models;
using EpamNUnit1.Tests;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using EpamNUnit1.Models;
using Newtonsoft.Json.Schema;

namespace ApiTest.Tests;

[TestFixture]
[Category("API")]
public class ApiTests : BaseApiTests
{
    [Test]
    public void GetUsers_FieldsExistTest()
    {
        RestResponse restResponse = _userService.GetUsersResponse();

        Logger.LogInfo<ApiTests>($"Request GetUsersResponse {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        string? jsonResponse = restResponse.Content;

        Assert.That(jsonResponse, Is.Not.Null.And.Not.Empty);

        string schema = File.ReadAllText("Schemas/UsersSchema.json");
        bool isSchemaValid = Utility.IsSchemaValid(jsonResponse, schema);

        Assert.That(isSchemaValid, Is.True);
    }

    [Test]
    public void GetUsers_CorrectHeader()
    {
        RestResponse<UserModel[]> restResponse = _userService.GetUsers();

        Logger.LogInfo<ApiTests>($"Request GetUsers {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        string? contentTypeHeader =
            restResponse.ContentHeaders?.FirstOrDefault(x => x.Name.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))?.Value;

        Assert.That(contentTypeHeader, Is.Not.Null.And.Not.Empty);
        Assert.That(contentTypeHeader, Is.EqualTo("application/json; charset=utf-8"));
    }

    [Test]
    public void GetUsers_FieldsAreCorrectTest()
    {
        RestResponse<UserModel[]> restResponse = _userService.GetUsers();

        Logger.LogInfo<ApiTests>($"Request GetUsers {restResponse.StatusCode}");

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
        CreateUserModel createUser = new CreateUserModel()
        {
            Name = "name",
            UserName = "userName"
        };

        RestResponse<UserCreatedModel> restResponse = _userService.CreateUser(createUser);

        Logger.LogInfo<ApiTests>($"Request CreateUser {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        UserCreatedModel? user = restResponse.Data;

        Assert.That(user, Is.Not.Null);
        Assert.That(user.Id, Is.AtLeast(1));
    }

    [Test]
    public void InvalidEndpoint_NotFoundTest()
    {
        RestResponse restResponse = _invalidEndpointService.Get();

        Logger.LogInfo<ApiTests>($"Request Get {restResponse.StatusCode}");

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}