using Microsoft.Playwright;

namespace PlaywrightDotnetEcommerce.Framework.Components;

public class HeaderComponent(IPage page)
{
    private readonly ILocator _shoppingCartLink = page.Locator("[data-test='shopping-cart-link']");

    private readonly ILocator _burgerMenuButton = page.GetByRole(AriaRole.Button, new PageGetByRoleOptions
    {
        Name = "Open Menu"
    });

    public ILocator ShoppingCartBadge => page.Locator("[data-test='shopping-cart-badge']");
    public ILocator PageTitle => page.Locator("[data-test='title']");

    public async Task GoToShoppingCartAsync()
    {
        await _shoppingCartLink.ClickAsync();
    }

    public async Task GoToBurgerMenuAsync()
    {
        await _burgerMenuButton.ClickAsync();
    }
}