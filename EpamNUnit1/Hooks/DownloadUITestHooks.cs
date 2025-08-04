using EpamNUnit1.Tests;
using TechTalk.SpecFlow;

namespace EpamNUnit1.Hooks;

[Binding]
[Scope(Tag = "DownloadUI")]
public class DownloadUITestHooks : BaseDownloadUITests
{
    private readonly ScenarioContext _context;

    public DownloadUITestHooks(ScenarioContext context)
    {
        _context = context;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        SetUp();
        _context["WebDriver"] = _driver;
        _context["DownloadPath"] = _downloadPath;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        TearDown();
    }
}
