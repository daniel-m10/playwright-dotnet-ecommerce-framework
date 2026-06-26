using Microsoft.Playwright;

namespace PlaywrightDotnetEcommerce.Framework.Pages;

public class CheckoutPage(IPage page)
{
    private readonly ILocator _firstNameField = page.Locator("[data-test='firstName']");
    private readonly ILocator _lastNameField = page.Locator("[data-test='lastName']");
    private readonly ILocator _postalCode = page.Locator("[data-test='postalCode']");
    private readonly ILocator _continueButton = page.Locator("[data-test='continue']");

    public async Task CheckoutAsync(string firstName, string lastName, string postalCode)
    {
        await _firstNameField.FillAsync(firstName);
        await _lastNameField.FillAsync(lastName);
        await _postalCode.FillAsync(postalCode);
        await _continueButton.ClickAsync();
    }
}