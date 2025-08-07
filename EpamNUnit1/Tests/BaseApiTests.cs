using EpamNUnit1.Services;
using RestSharp;

namespace EpamNUnit1.Tests;

public class BaseApiTests : BaseTests
{
    private const string url = "https://jsonplaceholder.typicode.com";
    protected UserService _userService;
    protected InvalidEndpointService _invalidEndpointService;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();

        _userService = new UserService(url);
        _invalidEndpointService = new InvalidEndpointService(url);
    }

    [TearDown]
    public override void TearDown()
    {
        base.TearDown();

        _userService.Dispose();
        _invalidEndpointService.Dispose();
    }
}
