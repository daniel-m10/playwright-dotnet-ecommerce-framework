namespace PlaywrightDotnetEcommerce.Framework.Configuration;

public class TestConfiguration
{
    public static string BaseUrl => Environment.GetEnvironmentVariable("BASE_URL")
                                    ?? "https://www.saucedemo.com";

    public static string StandardUser => Environment.GetEnvironmentVariable("STANDARD_USER") ?? "standard_user";

    public static string LockedOutUser => Environment.GetEnvironmentVariable("LOCKEDOUT_USER") ?? "locked_out_user";

    public static string Password => Environment.GetEnvironmentVariable("TEST_PASSWORD") ?? "secret_sauce";
}