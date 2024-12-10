using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ShoppingCart.Infrastructure.Enums;
using ShoppingCart.Infrastructure.Models;
using ShoppingCart.Infrastructure.Utilities;
using Unity;

namespace ShoppingCart.Infrastructure.Pages
{
    public class OrderPageRow
    {
        private readonly SkuId _skuId;
        private readonly Actions _actions;
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public OrderPageRow(SkuId skuId)
        {
            _skuId = skuId;
            _actions = App.Container.Resolve<Actions>();
            _driver = App.Container.Resolve<IWebDriver>();
            _wait = App.Container.Resolve<WebDriverWait>();
        }

        private IWebElement Row
        { 
            get
            {
                try
                {
                    return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(_skuId.ToString("d")))).FirstOrDefault();
                }
                catch (WebDriverTimeoutException)
                {
                    throw new NotFoundException($"Row with SKU ID '{_skuId}' not found");
                }
            }  
        }

        public IWebElement RowName => Row.FindElement(By.XPath(".//h4[@class='e2e-product-name']"));
        
        public IWebElement LicenseQuantity => Row.FindElement(By.XPath(".//quantity-select//span[@class = 'k-input-value-text']"));
        
        public IWebElement MaintenanceAndSupportQuantity => Row.FindElement(By.XPath(".//td[@data-label = 'Maintenance & Support']//span[@class = 'k-input-value-text']"));
        
        public IWebElement SubTotalPrice => Row.FindElement(By.XPath(".//div[contains(@class, 'e2e-cart-item-subtotal')]"));

        public IWebElement LicensePrice => Row.FindElement(By.XPath(".//td[@data-label='Licenses']//span[contains(@class, 'e2e-price-per-license')]"));

        public IWebElement LicenseSavePrice => Row.FindElement(By.XPath(".//td[@data-label='Licenses']//div[contains(@class, 'e2e-item-licenses-savings')]"));

        public IWebElement MaintenancePrice => Row.FindElement(By.XPath(".//span[@class='bold']"));

        public IWebElement TermPrice => Row.FindElement(By.XPath(".//td[@data-label='Maintenance & Support']//span[contains(@class, 'e2e-price-per-license')]"));

        public IWebElement TermSavingsPrice => Row.FindElement(By.XPath(".//td[@data-label='Maintenance & Support']//div[contains(@class, 'e2e-item-ms-savings')]"));

        public void EnterQuantityOfLicenses(int licenseQuantity)
        {
            LicenseQuantity.Click();
            Thread.Sleep(600);
            var dropDownValue = _driver.FindElement(By.XPath($"//kendo-popup//ul[@role='listbox']/li[child::div[text()={licenseQuantity}]]"));
            dropDownValue.Click();
            Thread.Sleep(600);
        }

        public void EnterYearsOfMaintenanceAndSupport(int maintenanceAndSupportQuantity)
        {
            MaintenanceAndSupportQuantity.Click();
            Thread.Sleep(600);
            var dropDownValue = _driver.FindElement(By.XPath($"//kendo-popup//kendo-list//ul/li[{maintenanceAndSupportQuantity}]"));
            dropDownValue.Click();
            Thread.Sleep(600);
        }

        public void AssertRowPrices(OrderPageRowPrices rowPrices)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(rowPrices.LicensePrice, LicensePrice.Text.ExctractPrice(), $"{RowName.Text} License price does not match.");
                Assert.AreEqual(rowPrices.LicenseSavePrice, LicenseSavePrice.Text.ExctractPrice(), $"{RowName.Text} License save price does not match.");
                Assert.AreEqual(rowPrices.MaintenancePrice, MaintenancePrice.Text.ExctractPrice(), $"{RowName.Text} Maintenance price does not match.");
                Assert.AreEqual(rowPrices.TermPrice, TermPrice.Text.ExctractPrice(), $"{RowName.Text} Maintenance term Price does not match.");
                Assert.AreEqual(rowPrices.TermSavePrice, TermSavingsPrice.Text.ExctractPrice(), $"{RowName.Text} Maintenance term savings price does not match.");
                Assert.AreEqual(rowPrices.SubTotalPrice, SubTotalPrice.Text.ExctractPrice(), $"{RowName.Text} Sub Total price does not match.");
            });
        }
    }
}
