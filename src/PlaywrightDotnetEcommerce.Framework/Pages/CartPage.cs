using Microsoft.Playwright;

namespace PlaywrightDotnetEcommerce.Framework.Pages;

public class CartPage(IPage page)
{
    private readonly ILocator _checkoutButton =
        page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Checkout" });

    public ILocator InventoryItem => page.Locator("[data-test='inventory-item']");
    public ILocator CartTitle => page.Locator("[data-test='secondary-header']");

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