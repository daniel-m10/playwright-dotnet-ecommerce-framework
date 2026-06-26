using Microsoft.Playwright;

namespace PlaywrightDotnetEcommerce.Framework.Pages;

public class CheckoutCompletePage(IPage page)
{
    public ILocator ConfirmationHeader => page.Locator("[data-test='complete-header']");
    public ILocator ConfirmationMessage => page.Locator("[data-test='complete-text']");
}