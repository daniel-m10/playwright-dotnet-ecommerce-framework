using Microsoft.Playwright;

namespace PlaywrightDotnetEcommerce.Framework.Pages;

public class CheckoutOverviewPage(IPage page)
{
    private readonly ILocator _finishButton =
        page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Finish" });

    public async Task FinishAsync()
    {
        await _finishButton.ClickAsync();
    }
}