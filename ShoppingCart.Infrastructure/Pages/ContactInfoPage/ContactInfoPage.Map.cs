using OpenQA.Selenium;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class ContactInfoPage
    {
        // Billing Information Form elements
        public IWebElement FirstNameBilling => FindElement(By.Id("biFirstName"));

        public IWebElement FirstNameBillingError => FindElement(By.XPath("//input[@id='biFirstName']/preceding-sibling::validation-messages//span"));

        public IWebElement LastNameBilling => FindElement(By.Id("biLastName"));

        public IWebElement LastNameBillingError => FindElement(By.XPath("//input[@id='biLastName']/preceding-sibling::validation-messages//span"));

        public IWebElement EmailBilling => FindElement(By.Id("biEmail"));

        public IWebElement EmailBillingError => FindElement(By.XPath("//input[@id='biEmail']/preceding-sibling::validation-messages//span"));

        public IWebElement CompanyBilling => FindElement(By.Id("biCompany"));

        public IWebElement CompanyBillingError => FindElement(By.XPath("//input[@id='biCompany']/preceding-sibling::validation-messages//span"));

        public IWebElement PhoneBilling => FindElement(By.Id("biPhone"));

        public IWebElement PhoneBillingError => FindElement(By.XPath("//input[@id='biPhone']/preceding-sibling::validation-messages//span"));

        public IWebElement AddressBilling => FindElement(By.Id("biAddress"));

        public IWebElement AddressBillingError => FindElement(By.XPath("//input[@id='biAddress']/preceding-sibling::validation-messages//span"));

        public IWebElement CountryBilling => FindElement(By.XPath("//kendo-combobox[@id='biCountry']/input"));

        public IWebElement CountryBillingError => FindElement(By.XPath("//kendo-combobox[@id='biCountry']/preceding-sibling::validation-messages//span"));

        public IWebElement CityBilling => FindElement(By.Id("biCity"));

        public IWebElement CityBillingError => FindElement(By.XPath("//input[@id='biCity']/preceding-sibling::validation-messages//span"));

        public IWebElement ZipCodeBilling => FindElement(By.Id("biZipCode"));

        public IWebElement ZipCodeBillingError => FindElement(By.XPath("//input[@id='biZipCode']/preceding-sibling::label/span"));

        public IWebElement EuropeanVatId => FindElement(By.Id("biCountryTaxIdentificationNumber"));

        public IWebElement EuropeanVatIdError => FindElement(By.XPath("//input[@id='biCountryTaxIdentificationNumber']/preceding-sibling::validation-messages//span"));

        // Checkbox
        public IWebElement SameAsBillingCheckbox => FindElement(By.XPath("//input[@type='checkbox']"));

        // License Holder Information Form elements
        public IWebElement FirstNameLicense => FindElement(By.Id("siFirstName"));

        public IWebElement FirstNameLicenseError => FindElement(By.XPath("//input[@id='siFirstName']/preceding-sibling::validation-messages//span"));

        public IWebElement LastNameLicense => FindElement(By.Id("siLastName"));

        public IWebElement LastNameLicenseError => FindElement(By.XPath("//input[@id='siLastName']/preceding-sibling::validation-messages//span"));

        public IWebElement EmailLicense => FindElement(By.Id("siEmail"));

        public IWebElement EmailLicenseError => FindElement(By.XPath("//input[@id='siEmail']/preceding-sibling::validation-messages//span"));

        public IWebElement CompanyLicense => FindElement(By.Id("siCompany"));

        public IWebElement CompanyLicenseError => FindElement(By.XPath("//input[@id='siCompany']/preceding-sibling::validation-messages//span"));

        public IWebElement AddressLicense => FindElement(By.Id("siAddress"));

        public IWebElement AddressLicenseError => FindElement(By.XPath("//input[@id='siAddress']/preceding-sibling::validation-messages//span"));

        public IWebElement CountryLicense => FindElement(By.XPath("//kendo-combobox[@id='siCountry']/input"));

        public IWebElement CountryLicenseError => FindElement(By.Id("//kendo-combobox[@id='siCountry']/preceding-sibling::validation-messages//span"));

        public IWebElement CityLicense => FindElement(By.Id("siCity"));

        public IWebElement CityLicenseError => FindElement(By.XPath("//input[@id='siCity']/preceding-sibling::validation-messages//span"));

        public IWebElement ZipCodeLicense => FindElement(By.Id("siZipCode"));

        public IWebElement ZipCodeLicenseError => FindElement(By.XPath("//input[@id='siZipCode']/preceding-sibling::validation-messages//span"));


        //Continue button
        public IWebElement ContinueButton => FindElementToBeClickable(By.XPath("//button[@type='button' and contains(@class, 'btn-primary')]"));
    }
}
