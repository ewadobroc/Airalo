using Microsoft.Playwright;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;



namespace AiraloAutomationTests
{
    public class Tests : PageTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            //Playwright instance

            //using var playwright = await Playwright.CreateAsync();

            //Browser
            //await using var browser = await playwright.Chromium.LaunchAsync();

            //page
            // var page = await browser.NewPageAsync();
            await Page.GotoAsync("https://www.airalo.com/");
            await Page.GetByTestId("£ GBP-header-language").ClickAsync();
            await Page.GetByTestId("currencies-list-search-bar").ClickAsync();
            await Page.GetByTestId("currencies-list-search-bar").FillAsync("usd");
            await Page.GetByTestId("USD-currency-select").ClickAsync();
            await Page.GetByTestId("UPDATE-button").ClickAsync();
            await Page.GetByTestId("search-input").ClickAsync();
            await Page.GetByTestId("search-input").FillAsync("Japan");
            await Page.Locator("span").Filter(new() { HasTextRegex = new Regex("^Japan$") }).ClickAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Moshi Moshi Moshi Moshi  COVERAGE Japan  DATA 1 GB  VALIDITY 7 Days PRICE $4.50" }).ClickAsync();

            await Expect(Page.Locator("[data-testid='sim-detail-operator-title']")).ToContainTextAsync("Moshi Moshi");
            await Expect(Page.Locator("[data-testid='sim-detail-info-list']")).ToContainTextAsync("COVERAGE \r\n        Japan\r\n          DATA \r\n        1 GB\r\n            VALIDITY \r\n        7 Days\r\n         \r\n    \r\n    \r\n PRICE \r\n        $4.50 USD");








        }
    }
}

