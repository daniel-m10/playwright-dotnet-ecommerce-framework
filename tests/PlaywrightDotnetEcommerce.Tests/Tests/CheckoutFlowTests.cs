using PlaywrightDotnetEcommerce.Framework.Configuration;
using PlaywrightDotnetEcommerce.Framework.Pages;
using PlaywrightDotnetEcommerce.Tests.Fixtures;

namespace PlaywrightDotnetEcommerce.Tests.Tests;

[TestFixture]
[Category("CheckoutFlow")]
public class CheckoutFlowTests : BaseTest
{
    private LoginPage _loginPage = null!;
    private InventoryPage _inventoryPage = null!;
    private CartPage _cartPage = null!;
    private CheckoutPage _checkoutPage = null!;
    private CheckoutOverviewPage _checkoutOverviewPage = null!;
    private CheckoutCompletePage _checkoutCompletePage = null!;

    [SetUp]
    public async Task Setup()
    {
        _loginPage = new LoginPage(Page);
        await _loginPage.GotoAsync();
        await _loginPage.LoginAsync(username: TestConfiguration.StandardUser, password: TestConfiguration.Password);

        _inventoryPage = new InventoryPage(Page);
        await _inventoryPage.AddItemToCartByNameAsync("Sauce Labs Backpack");
        await _inventoryPage.Header.GoToShoppingCartAsync();

        _cartPage = new CartPage(Page);
        await _cartPage.CheckoutAsync();

        _checkoutPage = new CheckoutPage(Page);
        _checkoutOverviewPage = new CheckoutOverviewPage(Page);
        _checkoutCompletePage = new CheckoutCompletePage(Page);
    }

    [Test]
    public async Task ShouldCompleteFullCheckoutFlow()
    {
        await _checkoutPage.CheckoutAsync(firstName: "John", lastName: "Doe", postalCode: "12345");
        await _checkoutOverviewPage.FinishAsync();

        await Expect(_checkoutCompletePage.ConfirmationHeader).ToBeVisibleAsync();
        await Expect(_checkoutCompletePage.ConfirmationMessage).ToBeVisibleAsync();
    }
}