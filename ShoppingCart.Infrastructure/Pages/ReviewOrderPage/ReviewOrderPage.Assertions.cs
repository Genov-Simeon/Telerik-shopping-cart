using NUnit.Framework;
using ShoppingCart.Infrastructure.Models;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class ReviewOrderPage
    {
        public void AssertBillingInformationIsCorrect(BillingInformation billingInformation)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(billingInformation.FirstName + " " + billingInformation.LastName, NameBilling.Text, "The full name in billing information does not match.");
                Assert.AreEqual(billingInformation.Email, EmailBilling.Text, "The email in billing information does not match.");
                Assert.AreEqual(billingInformation.Company, CompanyBilling.Text, "The company in billing information does not match.");
                Assert.AreEqual(billingInformation.Address, AddressBilling.Text, "The address in billing information does not match.");
                Assert.AreEqual(billingInformation.City + " " + billingInformation.ZipOrPostalCode, CityBilling.Text, "The city in billing information does not match.");
                Assert.AreEqual(billingInformation.Country, CountryBilling.Text, "The country in billing information does not match.");
            });
        }

        public void AssertLicenseHolderInformationIsCorrect(LicenseHolderInformation licenseHolderInformation)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(licenseHolderInformation.FirstName + " " + licenseHolderInformation.LastName, NameLicense.Text, "The full name in license holder information does not match.");
                Assert.AreEqual(licenseHolderInformation.Email, EmailLicense.Text, "The email in license holder information does not match.");
                Assert.AreEqual(licenseHolderInformation.Company, CompanyLicense.Text, "The company in license holder information does not match.");
                Assert.AreEqual(licenseHolderInformation.Address, AddressLicense.Text, "The address in license holder information does not match.");
                Assert.AreEqual(licenseHolderInformation.City + " " + licenseHolderInformation.ZipOrPostalCode, CityLicense.Text, "The city in license holder information does not match.");
                Assert.AreEqual(licenseHolderInformation.Country, CountryLicense.Text, "The country in license holder information does not match.");
            });
        }
    }
}
