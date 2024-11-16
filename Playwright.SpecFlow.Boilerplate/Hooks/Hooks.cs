using Microsoft.Playwright;

namespace Playwright.SpecFlow.Boilerplate.Hooks;

[Binding]
public class Hooks(ScenarioContext scenarioContext)
{
  private static IBrowser _browser = null!;
  private static IPage _page = null!;

  [BeforeTestRun]
  public static async Task SetUpBrowserAsync()
  {
    var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
    var isCi = Environment.GetEnvironmentVariable("CI") == "true";
    _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
      Headless = isCi,
      SlowMo = 50,
      Timeout = 0
    });
    _page = await (await _browser.NewContextAsync(new BrowserNewContextOptions
    {
      ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
      BaseURL = "https://bing.com",
    })).NewPageAsync();
  }

  [AfterTestRun]
  public static async Task TearDownBrowserAsync()
  {
    await _browser.CloseAsync();
    await _browser.DisposeAsync();
  }

  [BeforeScenario]
  public async Task SetUpScenarioAsync()
  {
    scenarioContext["browser"] = _browser;
    scenarioContext["page"] = _page;
    await _page.GotoAsync("/");
  }

  [AfterScenario]
  public static async Task TearDownScenarioAsync()
  {
    await _page.CloseAsync();
  }
}
