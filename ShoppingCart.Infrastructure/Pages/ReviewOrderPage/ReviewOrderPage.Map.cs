using OpenQA.Selenium;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class ReviewOrderPage
    {
        //Billing Information 
        IWebElement NameBilling => FindElement(By.XPath("//div[contains(@class, 'e2e-billing-info-fullName')]"));
        IWebElement EmailBilling => FindElement(By.XPath("//div[contains(@class, 'e2e-billing-info-email')]"));
        IWebElement CompanyBilling => FindElement(By.XPath("//div[contains(@class, 'e2e-billing-info-company')]"));
        IWebElement AddressBilling => FindElement(By.XPath("//div[contains(@class, 'e2e-billing-info-address')]"));
        IWebElement CityBilling => FindElement(By.XPath("//div[contains(@class, 'e2e-billing-info-city')]"));
        IWebElement CountryBilling => FindElement(By.XPath("//div[contains(@class, 'e2e-billing-info-country')]"));

        //License Holder Information
        IWebElement NameLicense => FindElement(By.XPath("//div[contains(@class, 'e2e-shipping-info-fullName')]"));
        IWebElement EmailLicense => FindElement(By.XPath("//div[contains(@class, 'e2e-shipping-info-email')]"));
        IWebElement CompanyLicense => FindElement(By.XPath("//div[contains(@class, 'e2e-shipping-info-company')]"));
        IWebElement AddressLicense => FindElement(By.XPath("//div[contains(@class, 'e2e-shipping-info-address')]"));
        IWebElement CityLicense => FindElement(By.XPath("//div[contains(@class, 'e2e-shipping-info-city')]"));
        IWebElement CountryLicense => FindElement(By.XPath("//div[contains(@class, 'e2e-shipping-info-country')]"));
    }
}
