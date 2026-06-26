# playwright-dotnet-ecommerce-framework

A professional E2E automation framework built with Playwright .NET, C#, and NUnit targeting Sauce Demo.

## Purpose

This is the main portfolio repository for the Playwright .NET SDET Portfolio Program. It demonstrates clean E2E automation architecture, Page Object Model, reusable components, CI/CD with GitHub Actions, and interview-ready framework design.

## Tech Stack

- C#
- .NET 10 LTS
- Playwright .NET 1.61.0
- NUnit
- Microsoft.Playwright.NUnit
- Rider (recommended IDE)
- GitHub Actions
- dotnet CLI

## Project Structure

```text
playwright-dotnet-ecommerce-framework/
  src/
    PlaywrightDotnetEcommerce.Framework/
      Components/       # Reusable UI components (HeaderComponent)
      Configuration/    # TestConfiguration with environment variable support
      Pages/            # Page Objects encapsulating locators and interactions
  tests/
    PlaywrightDotnetEcommerce.Tests/
      Fixtures/         # BaseTest with tracing on failure
      Tests/            # NUnit test fixtures organized by feature
```

## Setup

```powershell
dotnet restore
dotnet build
pwsh tests/PlaywrightDotnetEcommerce.Tests/bin/Debug/net10.0/playwright.ps1 install
```

## Running Tests

Run all tests:

```powershell
dotnet test
```

Run by category:

```powershell
dotnet test --filter "Category=Login"
dotnet test --filter "Category=Inventory"
dotnet test --filter "Category=Cart"
dotnet test --filter "Category=CheckoutFlow"
```

## Test Coverage

| Fixture | Category | Tests |
|---|---|---|
| LoginTests | Login | Valid login, invalid password, locked out user, empty credentials |
| InventoryTests | Inventory | Products displayed, sort by name, sort by price, add to cart |
| CartTests | Cart | Navigate to cart, remove product |
| CheckoutFlowTests | CheckoutFlow | Full E2E happy path checkout |

**Total: 11 tests**

## Architecture Notes

- **Two-project structure** separates framework logic from test logic. `Framework` has no knowledge of NUnit — it only depends on `Microsoft.Playwright`.
- **Page Object Model** is used from the beginning. Tests describe scenarios. Page Objects encapsulate locators and interactions. No raw locators appear in test methods.
- **HeaderComponent** is composed into page objects that share the persistent header UI. Tests access it via `_inventoryPage.Header.GoToShoppingCartAsync()`.
- **TestConfiguration** reads from environment variables with hardcoded fallbacks, supporting both local and CI execution without code changes.
- **BaseTest** owns tracing setup and teardown. Traces are saved as zip artifacts only on failure.
- **Locator strategy** prefers `data-test` CSS attribute selectors for stability. Role-based locators are used for buttons and interactive elements with visible text.

## CI/CD

GitHub Actions runs on every push and PR to `main`.

- Runner: `ubuntu-latest`
- Credentials are stored as GitHub Secrets
- Playwright trace artifacts are uploaded on failure

## Debugging and Artifacts

When a test fails locally, a trace zip is saved to:

```
playwright-traces/{TestName}.zip
```

Open it with:

```powershell
pwsh tests/PlaywrightDotnetEcommerce.Tests/bin/Debug/net10.0/playwright.ps1 show-trace playwright-traces/{TestName}.zip
```

In CI, trace artifacts are available for download from the GitHub Actions run summary.

## Next Improvements

- Add `CheckoutPage` validation scenarios
- Add parallel execution configuration
- Extend to additional Sauce Demo user types
- Add API layer for test data setup