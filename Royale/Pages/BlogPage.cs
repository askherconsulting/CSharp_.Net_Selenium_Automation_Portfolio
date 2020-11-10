using OpenQA.Selenium;

namespace Royale.Pages
{
    public class BlogPage : PageBase
    {
        public readonly BlogPageMap Map;

        public BlogPage(IWebDriver driver) : base(driver)
        {
            Map = new BlogPageMap(driver);
        }

        public (string Category, string Arena) GetCardCategory()
        {
            var categories = Map.BlogDate.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }
    }

    public class BlogPageMap
    {
        IWebDriver _driver;

        public BlogPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BlogName => _driver.FindElement(By.CssSelector("div[class*='cardName']"));

        public IWebElement BlogDate => _driver.FindElement(By.CssSelector("div[class*='card__rarity']"));

        public IWebElement BlogRarity => _driver.FindElement(By.CssSelector("div[class*='rarityCaption']"));
    }
}