using OpenQA.Selenium;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class ConfigurePurchasePage
    {
        public IWebElement ContinueButton => FindElement(By.XPath("//span[@class='btn-content' and text()='Continue']"));

        public IWebElement  Option1 => FindElement(By.Id("addon-option-0"));

        public IWebElement Option2 => FindElement(By.Id("addon-option-1"));
    }
}
