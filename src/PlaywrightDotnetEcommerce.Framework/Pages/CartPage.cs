using Microsoft.Playwright;
using PlaywrightDotnetEcommerce.Framework.Components;

namespace PlaywrightDotnetEcommerce.Framework.Pages;

public class CartPage(IPage page)
{
    private readonly ILocator _checkoutButton =
        page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Checkout" });

    public ILocator InventoryItem => page.Locator("[data-test='inventory-item']");
    public HeaderComponent Header => new(page);

    public async Task RemoveItemFromCartByNameAsync(string productName)
    {
        var removeButton = InventoryItem
            .Filter(new LocatorFilterOptions { HasText = productName })
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Remove" });

        await removeButton.ClickAsync();
    }

    public async Task CheckoutAsync()
    {
        await _checkoutButton.ClickAsync();
    }
}