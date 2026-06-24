using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Interfaces;

namespace PlaywrightDotnetEcommerce.Tests.Fixtures;

public class BaseTest : PageTest
{
    [SetUp]
    public async Task StartTracing()
    {
        await Context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task StopTracing()
    {
        var failed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;

        if (failed)
        {
            var testPath = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.Name}.zip"
            );

            await Context.Tracing.StopAsync(new TracingStopOptions { Path = testPath });
        }
        else
        {
            await Context.Tracing.StopAsync(new TracingStopOptions());
        }
    }
}