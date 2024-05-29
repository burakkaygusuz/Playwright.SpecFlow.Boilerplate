using Microsoft.Playwright;
using NUnit.Framework;
using static Microsoft.Playwright.Assertions;

namespace Playwright.SpecFlow.Boilerplate.Steps;

[Binding]
public class SearchEngineSteps(ScenarioContext scenarioContext)
{
    private readonly IPage _page = scenarioContext.Get<IPage>("page");

    [Given(@"I am on the (.*) search engine")]
    public async Task GivenIAmOnTheBingSearchEngine(string page)
    {
        await Expect(_page).ToHaveTitleAsync(page);
    }

    [When(@"I enter (.*) in the search box")]
    public async Task WhenIEnterInTheSearchBox(string specFlow)
    {
        var textArea = _page.Locator("#sb_form_q");
        await Expect(textArea).ToBeEmptyAsync();
        await textArea.PressSequentiallyAsync(specFlow, new LocatorPressSequentiallyOptions
        {
            Delay = 100
        });
        await Expect(textArea).ToHaveValueAsync(specFlow);
    }

    [When(@"I click the search button")]
    public async Task WhenIClickTheSearchButton()
    {
        await _page.Locator("#search_icon").ClickAsync();
    }

    [Then(@"I should see search results related to (.*)")]
    public async Task ThenIShouldSeeSearchResultsRelatedTo(string specFlow)
    {
        var searchResults = await _page.QuerySelectorAllAsync("ol > li > h2 > a");
        foreach (var elementHandle in searchResults)
        {
            var text = await elementHandle.InnerTextAsync();
            Assert.That(text, Contains.Substring(specFlow));
        }
    }
}