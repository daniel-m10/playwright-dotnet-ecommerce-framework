using Microsoft.Playwright;
using PlaywrightDotnetEcommerce.Framework.Configuration;

namespace PlaywrightDotnetEcommerce.Framework.Pages;

public class LoginPage(IPage page)
{
    private readonly ILocator _usernameField = page.Locator("[data-test='username']");
    private readonly ILocator _passwordField = page.Locator("[data-test='password']");

    private readonly ILocator _loginButton =
        page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Login" });

    public async Task LoginAsync(string username, string password)
    {
        await _usernameField.FillAsync(username);
        await _passwordField.FillAsync(password);
        await _loginButton.ClickAsync();
    }

    public async Task GotoAsync()
    {
        await page.GotoAsync(TestConfiguration.BaseUrl);
    }
    
    public ILocator ErrorMessageContainer { get; } = page.Locator("[data-test='error']");
}