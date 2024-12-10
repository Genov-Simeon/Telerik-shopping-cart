using NUnit.Framework;
using OpenQA.Selenium;
using ShoppingCart.Infrastructure.Models;

namespace ShoppingCart.Infrastructure.Pages
{
    public partial class ContactInfoPage
    {
        public void AssertAllFieldsNotExceedMaxLength(BillingInformation billingInformation, LicenseHolderInformation licenseHolderInformation)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(billingInformation.FirstName?.Length <= MaxLengthValidations.FirstNameMaxLength || billingInformation.FirstName == null, "First Name max length exceeds allowance");
                Assert.IsTrue(billingInformation.LastName?.Length <= MaxLengthValidations.LastNameMaxLength || billingInformation.LastName == null, "Last Name max length exceeds allowance");
                Assert.IsTrue(billingInformation.Email?.Length <= MaxLengthValidations.EmailMaxLength || billingInformation.Email == null, "Email max length exceeds allowance");
                Assert.IsTrue(billingInformation.Company?.Length <= MaxLengthValidations.CompanyMaxLength || billingInformation.Company == null, "Company max length exceeds allowance");
                Assert.IsTrue(billingInformation.Phone?.Length <= MaxLengthValidations.PhoneMaxLength || billingInformation.Phone == null, "Phone max length exceeds allowance");
                Assert.IsTrue(billingInformation.Address?.Length <= MaxLengthValidations.AddressMaxLength || billingInformation.Address == null, "Address max length exceeds allowance");
                Assert.IsTrue(billingInformation.City?.Length <= MaxLengthValidations.CityMaxLength || billingInformation.City == null, "City max length exceeds allowance");
                Assert.IsTrue(billingInformation.ZipOrPostalCode?.Length <= MaxLengthValidations.ZipPostalCodeMaxLength || billingInformation.ZipOrPostalCode == null, "Zip or Postal Code max length exceeds allowance");

                Assert.IsTrue(licenseHolderInformation.FirstName?.Length <= MaxLengthValidations.FirstNameMaxLength || licenseHolderInformation.FirstName == null, "License Holder First Name max length exceeds allowance");
                Assert.IsTrue(licenseHolderInformation.LastName?.Length <= MaxLengthValidations.LastNameMaxLength || licenseHolderInformation.LastName == null, "License Holder Last Name max length exceeds allowance");
                Assert.IsTrue(licenseHolderInformation.Email?.Length <= MaxLengthValidations.EmailMaxLength || licenseHolderInformation.Email == null, "License Holder Email max length exceeds allowance");
                Assert.IsTrue(licenseHolderInformation.Company?.Length <= MaxLengthValidations.CompanyMaxLength || licenseHolderInformation.Company == null, "License Holder Company max length exceeds allowance");
                Assert.IsTrue(licenseHolderInformation.Address?.Length <= MaxLengthValidations.AddressMaxLength || licenseHolderInformation.Address == null, "License Holder Address max length exceeds allowance");
                Assert.IsTrue(licenseHolderInformation.City?.Length <= MaxLengthValidations.CityMaxLength || licenseHolderInformation.City == null, "License Holder City max length exceeds allowance");
                Assert.IsTrue(licenseHolderInformation.ZipOrPostalCode?.Length <= MaxLengthValidations.ZipPostalCodeMaxLength || licenseHolderInformation.ZipOrPostalCode == null, "License Holder Zip or Postal Code max length exceeds allowance");
            });
        }

        public void AssertInvalidFieldValidationMessage()
        {
            Assert.Multiple(() =>
            {
                // Billing Information Validations
                AssertElementIsDisplayed(FirstNameBillingError, "First Name billing error message");
                AssertElementIsDisplayed(LastNameBillingError, "Last Name billing error message");
                AssertElementIsDisplayed(EmailBillingError, "Email billing error message");
                AssertElementIsDisplayed(CompanyBillingError, "Company billing error message");
                AssertElementIsDisplayed(PhoneBillingError, "Phone billing error message");
                AssertElementIsDisplayed(AddressBillingError, "Address billing error message");
                AssertElementIsDisplayed(CityBillingError, "City billing error message");

                // License Holder Information Validations
                AssertElementIsDisplayed(FirstNameLicenseError, "First Name license holder error message");
                AssertElementIsDisplayed(LastNameLicenseError, "Last Name license holder error message");
                AssertElementIsDisplayed(EmailLicenseError, "Email license holder error message");
                AssertElementIsDisplayed(CompanyLicenseError, "Company license holder error message");
                AssertElementIsDisplayed(AddressLicenseError, "Address license holder error message");
                AssertElementIsDisplayed(CityLicenseError, "City license holder error message");
            });
        }

        private void AssertElementIsDisplayed(IWebElement element, string elementName)
        {
            try
            {
                bool isDisplayed = element.Displayed;
                Assert.IsTrue(isDisplayed, $"{elementName} is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"{elementName} does not exist on the page.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Timeout while waiting for {elementName} to be displayed.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected error occurred while validating {elementName}: {ex.Message}");
            }
        }
    }
}
