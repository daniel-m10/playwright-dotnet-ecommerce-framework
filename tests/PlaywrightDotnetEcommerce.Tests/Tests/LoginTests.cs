using Microsoft.Playwright;
using PlaywrightDotnetEcommerce.Framework.Configuration;
using PlaywrightDotnetEcommerce.Framework.Pages;
using PlaywrightDotnetEcommerce.Tests.Fixtures;

namespace PlaywrightDotnetEcommerce.Tests.Tests;

[TestFixture]
[Category("Login")]
public class LoginTests : BaseTest
{
    private LoginPage _loginPage = null!;

    [SetUp]
    public async Task SetUp()
    {
        _loginPage = new LoginPage(Page);
        await _loginPage.GotoAsync();
    }

    [Test]
    public async Task ShouldLoginWithValidCredentials()
    {
        await _loginPage.LoginAsync(username: TestConfiguration.StandardUser, password: TestConfiguration.Password);

        await Expect(Page).ToHaveURLAsync($"{TestConfiguration.BaseUrl}/inventory.html");
    }

    [Test]
    public async Task ShouldShowErrorForInvalidPassword()
    {
        await _loginPage.LoginAsync(username: TestConfiguration.StandardUser, password: "wrongPassword");

        await Expect(_loginPage.ErrorMessageContainer).ToContainTextAsync("Username and password do not match");
    }

    [Test]
    public async Task ShouldShowErrorForLockedOutUser()
    {
        await _loginPage.LoginAsync(username: TestConfiguration.LockedOutUser, password: TestConfiguration.Password);

        await Expect(_loginPage.ErrorMessageContainer).ToContainTextAsync("Sorry, this user has been locked out");
    }

    [Test]
    public async Task ShouldShowErrorForEmptyCredentials()
    {
        await _loginPage.LoginAsync(username: string.Empty, password: string.Empty);
        
        await Expect(_loginPage.ErrorMessageContainer).ToContainTextAsync("Username is required");
    }
}