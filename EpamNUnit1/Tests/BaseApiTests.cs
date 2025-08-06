using RestSharp;

namespace EpamNUnit1.Tests;

public class BaseApiTests : BaseTests
{
    private const string url = "https://jsonplaceholder.typicode.com";
    protected RestClient _restClient;

    public override void SetUp()
    {
        base.SetUp();

        RestClientOptions restClientOptions = new RestClientOptions(url);
        _restClient = new RestClient(restClientOptions);
    }

    public override void TearDown()
    {
        base.TearDown();

        _restClient.Dispose();
    }
}
