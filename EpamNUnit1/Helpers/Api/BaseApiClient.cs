using RestSharp;

namespace EpamNUnit1.Helpers.Api
{
    public class BaseApiClient : IDisposable
    {
        private readonly RestClient _restClient;

        public BaseApiClient(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public RestResponse<T> Execute<T>(RestRequest restRequest)
        {
            return _restClient.Execute<T>(restRequest);
        }

        public RestResponse Execute(RestRequest restRequest)
        {
            return _restClient.Execute(restRequest);
        }

        public void Dispose()
        {
            _restClient.Dispose();
        }
    }
}
