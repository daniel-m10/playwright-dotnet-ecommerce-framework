using PlaywrightDotnetEcommerce.Framework.Configuration;
using PlaywrightDotnetEcommerce.Framework.Pages;
using PlaywrightDotnetEcommerce.Tests.Fixtures;

namespace PlaywrightDotnetEcommerce.Tests.Tests;

[TestFixture]
[Category("Inventory")]
public class InventoryTests : BaseTest
{
    private LoginPage _loginPage = null!;
    private InventoryPage _inventoryPage = null!;

    [SetUp]
    public async Task Setup()
    {
        _loginPage = new LoginPage(Page);

        await _loginPage.GotoAsync();
        await _loginPage.LoginAsync(username: TestConfiguration.StandardUser, password: TestConfiguration.Password);
        _inventoryPage = new InventoryPage(Page);
    }

    [Test]
    public async Task ShouldDisplayProductsAfterLogin()
    {
        await Expect(_inventoryPage.Title).ToHaveTextAsync("Products");
    }

    [Test]
    public async Task ShouldSortProductsByNameAscending()
    {
        await _inventoryPage.SortByAsync("Name (A to Z)");

        await Expect(_inventoryPage.FirstItemName).ToContainTextAsync("Sauce Labs Backpack");
    }

    [Test]
    public async Task ShouldSortProductsByPriceAscending()
    {
        await _inventoryPage.SortByAsync("Price (low to high)");

        await Expect(_inventoryPage.FirstItemPrice).ToContainTextAsync("7.99");
    }
    
    [Test]
    public async Task ShouldAddProductToCart()
    {
        await _inventoryPage.AddItemToCartByNameAsync("Sauce Labs Backpack");
        
        await Expect(_inventoryPage.ShoppingCartBadge).ToHaveTextAsync("1");
    }
}