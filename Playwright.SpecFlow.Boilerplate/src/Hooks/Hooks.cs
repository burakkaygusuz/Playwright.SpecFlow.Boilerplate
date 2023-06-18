using Microsoft.Playwright;

namespace Playwright.SpecFlow.Boilerplate.Hooks;

[Binding]
public class Hooks
{
    private static IBrowser _browser = null!;
    private static IPage _page = null!;
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeTestRun]
    public static async Task BeforeTestRunAsync()
    {
        var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
            Timeout = 60000
        });

        var context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
            BaseURL = "https://bing.com"
        });

        _page = await context.NewPageAsync();
    }

    [AfterTestRun]
    public static async Task AfterTestRunAsync()
    {
        await _browser.CloseAsync();
        await _browser.DisposeAsync();
    }

    [BeforeScenario]
    public async Task BeforeScenarioAsync()
    {
        _scenarioContext["browser"] = _browser;
        _scenarioContext["page"] = _page;
        await _page.GotoAsync("/");
    }

    [AfterScenario]
    public static async Task AfterScenario()
    {
        await _page.CloseAsync();
    }
}