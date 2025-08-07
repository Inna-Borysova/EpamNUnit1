using ApiTest.Models;
using EpamNUnit1.Helpers.Api;
using EpamNUnit1.Models;
using RestSharp;

namespace EpamNUnit1.Services;

public class UserService : IDisposable
{
    private const string resource = "users";
    private readonly BaseApiClient _baseApiClient;

    public UserService(string baseUrl)
    {
        _baseApiClient = new BaseApiClient(baseUrl);
    }

    public RestResponse<UserModel[]> GetUsers()
    {
       RestRequest restRequest = ApiRequestBuilder.Create(resource, Method.Get).Build();
       return _baseApiClient.Execute<UserModel[]>(restRequest);
    }

    public RestResponse GetUsersResponse()
    {
        RestRequest restRequest = ApiRequestBuilder.Create(resource, Method.Get).Build();
        return _baseApiClient.Execute(restRequest);
    }

    public RestResponse<UserCreatedModel> CreateUser(CreateUserModel createUserModel)
    {
        RestRequest restRequest = 
            ApiRequestBuilder.Create(resource, Method.Post)
                .AddJsonBody(createUserModel)
                .Build();

        return _baseApiClient.Execute<UserCreatedModel>(restRequest);
    }

    public void Dispose()
    {
        _baseApiClient.Dispose();
    }
}
