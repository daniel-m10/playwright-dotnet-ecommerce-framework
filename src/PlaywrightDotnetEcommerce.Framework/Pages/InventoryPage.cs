using Microsoft.Playwright;
using PlaywrightDotnetEcommerce.Framework.Components;

namespace PlaywrightDotnetEcommerce.Framework.Pages;

public class InventoryPage(IPage page)
{
    private readonly ILocator _sortDropdown = page.Locator("[data-test='product-sort-container']");
    private readonly ILocator _inventoryItems = page.Locator("[data-test='inventory-item']");
    
    public HeaderComponent Header => new(page);
    public ILocator FirstItemName => _inventoryItems.First.Locator("[data-test='inventory-item-name']");
    public ILocator FirstItemPrice => _inventoryItems.First.Locator("[data-test='inventory-item-price']");


    public async Task AddItemToCartByNameAsync(string productName)
    {
        var product = _inventoryItems
            .Filter(new LocatorFilterOptions { HasText = productName })
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Add to cart" });

        await product.ClickAsync();
    }

    public async Task SortByAsync(string option) => await _sortDropdown
        .SelectOptionAsync(new SelectOptionValue { Label = option });
}