using OpenQA.Selenium;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class PurchasePage
    {
        public IWebElement GetProductBuyNowButton(string productName)
        {
            return FindElement(By.XPath($"//th[contains(@class, '{productName}')]//a[text()='Buy now']"));
        }

        public IWebElement KendoUIBuyButton => FindElement(By.XPath("(//a[contains(text(), 'Buy Kendo UI Bundle')])[1]"));

        public IWebElement KendoReactBuyButton => FindElement(By.XPath("(//a[contains(text(), 'Buy KendoReact')])[1]"));
    }
}
