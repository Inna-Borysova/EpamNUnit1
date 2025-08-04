using EpamNUnit1.Helpers;

namespace EpamNUnit1.Tests;

public class BaseTests
{
    [OneTimeSetUp]
    public void GlobalSetUp()
    {
        Logger.LogInfo<BaseUITests>("=== TEST RUN STARTED ===");
    }

    [SetUp]
    public virtual void SetUp()
    {
        Logger.LogInfo<BaseUITests>("Test Started: " + TestContext.CurrentContext.Test.Name);
    }

    [TearDown]
    public virtual void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Logger.LogError<BaseUITests>("Test Failed: " + TestContext.CurrentContext.Test.Name);
            Logger.LogError<BaseUITests>("Error: " + TestContext.CurrentContext.Result.Message);
        }
        else
        {
            Logger.LogInfo<BaseUITests>("Test Passed: " + TestContext.CurrentContext.Test.Name);
        }
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        Logger.LogInfo<BaseUITests>("=== TEST RUN FINISHED ===");
    }
}