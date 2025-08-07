using EpamNUnit1.Helpers.Api;
using RestSharp;

namespace EpamNUnit1.Services;

public class InvalidEndpointService : IDisposable
{
    private const string resource = "invalidendpoint";
    private readonly BaseApiClient _baseApiClient;

    public InvalidEndpointService(string baseUrl)
    {
        _baseApiClient = new BaseApiClient(baseUrl);
    }

    public RestResponse Get()
    {
        RestRequest restRequest = ApiRequestBuilder.Create(resource, Method.Get).Build();
        return _baseApiClient.Execute(restRequest);
    }

    public void Dispose()
    {
        _baseApiClient.Dispose();
    }
}
