using PlaywrightDotnetEcommerce.Framework.Configuration;
using PlaywrightDotnetEcommerce.Framework.Pages;
using PlaywrightDotnetEcommerce.Tests.Fixtures;

namespace PlaywrightDotnetEcommerce.Tests.Tests;

[TestFixture]
[Category("Cart")]
public class CartTests : BaseTest
{
    private LoginPage _loginPage = null!;
    private InventoryPage _inventoryPage = null!;
    private CartPage _cartPage = null!;

    [SetUp]
    public async Task SetUp()
    {
        _loginPage = new LoginPage(Page);
        
        await _loginPage.GotoAsync();
        await _loginPage.LoginAsync(username: TestConfiguration.StandardUser, password: TestConfiguration.Password);
        
        _inventoryPage = new InventoryPage(Page);
        _cartPage = new CartPage(Page);
    }

    [Test]
    public async Task ShouldNavigateToCartAfterAddingProduct()
    {
        await _inventoryPage.AddItemToCartByNameAsync("Sauce Labs Backpack");
        await _inventoryPage.Header.GoToShoppingCartAsync();
        
        await Expect(_cartPage.Header.PageTitle).ToBeVisibleAsync();
    }

    [Test]
    public async Task ShouldRemoveProductFromCart()
    {
        await _inventoryPage.AddItemToCartByNameAsync("Sauce Labs Backpack");
        await _inventoryPage.Header.GoToShoppingCartAsync();
        
        await _cartPage.RemoveItemFromCartByNameAsync("Sauce Labs Backpack");
        
        await Expect(_cartPage.InventoryItem).ToHaveCountAsync(0);
    }
}