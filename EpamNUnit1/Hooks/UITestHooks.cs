using EpamNUnit1.Tests;
using TechTalk.SpecFlow;

namespace EpamNUnit1.Hooks;

[Binding]
[Scope(Tag = "UI")]
public class UITestHooks : BaseUITests
{
    private readonly ScenarioContext _context;

    public UITestHooks(ScenarioContext context)
    {
        _context = context;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        SetUp();
        _context["WebDriver"] = _driver;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        TearDown();
    }
}
