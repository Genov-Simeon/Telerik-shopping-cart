using OpenQA.Selenium;
using ShoppingCart.Infrastructure.Models;
using ShoppingCart.Infrastructure.Utilites;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class ContactInfoPage : BasePage
    {
        public ContactInfoPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillAllFormFields(BillingInformation billingInformation, LicenseHolderInformation licenseHolderInformation)
        {
            FirstNameBilling.SendKeys(billingInformation.FirstName ?? string.Empty);
            LastNameBilling.SendKeys(billingInformation.LastName ?? string.Empty);
            EmailBilling.SendKeys(billingInformation.Email ?? string.Empty);
            CompanyBilling.SendKeys(billingInformation.Company ?? string.Empty);
            AddressBilling.SendKeys(billingInformation.Address ?? string.Empty);
            PhoneBilling.SendKeys(billingInformation.Phone ?? string.Empty);
            CountryBilling.SendKeys(billingInformation.Country ?? string.Empty);
            CityBilling.SendKeys(billingInformation.City ?? string.Empty);
            ZipCodeBilling.SendKeys(billingInformation.ZipOrPostalCode ?? string.Empty);
            FirstNameLicense.SendKeys(licenseHolderInformation.FirstName ?? string.Empty);
            LastNameLicense.SendKeys(licenseHolderInformation.LastName ?? string.Empty);
            EmailLicense.SendKeys(licenseHolderInformation.Email ?? string.Empty);
            CompanyLicense.SendKeys(licenseHolderInformation.Company ?? string.Empty);
            AddressLicense.SendKeys(licenseHolderInformation.Address ?? string.Empty);
            CountryLicense.SendKeys(licenseHolderInformation.Country ?? string.Empty);
            CityLicense.SendKeys(licenseHolderInformation.City ?? string.Empty);
            ZipCodeLicense.SendKeys(licenseHolderInformation.ZipOrPostalCode ?? string.Empty);
        }

        public void FillBillingInformation(BillingInformation billingInformation)
        {
            FirstNameBilling.SendKeys(billingInformation.FirstName ?? string.Empty);
            LastNameBilling.SendKeys(billingInformation.LastName ?? string.Empty);
            EmailBilling.SendKeys(billingInformation.Email ?? string.Empty);
            CompanyBilling.SendKeys(billingInformation.Company ?? string.Empty);
            AddressBilling.SendKeys(billingInformation.Address ?? string.Empty);
            PhoneBilling.SendKeys(billingInformation.Phone ?? string.Empty);
            CountryBilling.SendKeys(billingInformation.Country ?? string.Empty);
            CityBilling.SendKeys(billingInformation.City ?? string.Empty);
            ZipCodeBilling.SendKeys(billingInformation.ZipOrPostalCode ?? string.Empty);
        }

        public BillingInformation ExtractBillingInformationFields()
        {
            return new BillingInformation
            {
                FirstName = FirstNameBilling.GetDomProperty("value"),
                LastName = LastNameBilling.GetDomProperty("value"),
                Email = EmailBilling.GetDomProperty("value"),
                Company = CompanyBilling.GetDomProperty("value"),
                Phone = PhoneBilling.GetDomProperty("value"),
                Address = AddressBilling.GetDomProperty("value"),
                City = CityBilling.GetDomProperty("value"),
                ZipOrPostalCode = ZipCodeBilling.GetDomProperty("value")
            };
        }

        public void FillLicenseInformation(LicenseHolderInformation licenseHolderInformation)
        {
            FirstNameLicense.SendKeys(licenseHolderInformation.FirstName ?? string.Empty);
            LastNameLicense.SendKeys(licenseHolderInformation.LastName ?? string.Empty);
            EmailLicense.SendKeys(licenseHolderInformation.Email ?? string.Empty);
            CompanyLicense.SendKeys(licenseHolderInformation.Company ?? string.Empty);
            AddressLicense.SendKeys(licenseHolderInformation.Address ?? string.Empty);
            CountryLicense.SendKeys(licenseHolderInformation.Country ?? string.Empty);
            CityLicense.SendKeys(licenseHolderInformation.City ?? string.Empty);
            ZipCodeLicense.SendKeys(licenseHolderInformation.ZipOrPostalCode ?? string.Empty);
        }

        public LicenseHolderInformation ExtractLicenseInformationFields()
        {
            return new LicenseHolderInformation
            {
                FirstName = FirstNameBilling.GetDomProperty("value"),
                LastName = LastNameBilling.GetDomProperty("value"),
                Email = EmailBilling.GetDomProperty("value"),
                Company = CompanyBilling.GetDomProperty("value"),
                Address = AddressBilling.GetDomProperty("value"),
                City = CityBilling.GetDomProperty("value"),
                ZipOrPostalCode = ZipCodeBilling.GetDomProperty("value")
            };
        }
    }
}
