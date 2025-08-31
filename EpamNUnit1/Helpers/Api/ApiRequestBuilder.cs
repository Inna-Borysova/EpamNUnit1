using RestSharp;

namespace EpamNUnit1.Helpers.Api;

public class ApiRequestBuilder
{
    private readonly RestRequest _request;

    private ApiRequestBuilder(string resource, Method method)
    {
        _request = new RestRequest(resource, method);
    }

    public static ApiRequestBuilder Create(string resource, Method method)
    {
        return new ApiRequestBuilder(resource, method);
    }

    public ApiRequestBuilder AddHeader(string name, string value)
    {
        _request.AddHeader(name, value);
        return this;
    }

    public ApiRequestBuilder AddJsonBody(object body)
    {
        _request.AddJsonBody(body);
        return this;
    }

    public RestRequest Build()
    {
        return _request;
    }
}
