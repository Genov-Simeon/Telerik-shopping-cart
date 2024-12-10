using ShoppingCart.Infrastructure;
using ShoppingCart.Infrastructure.Enums;
using ShoppingCart.Infrastructure.Factories;
using ShoppingCart.Infrastructure.Models;
using ShoppingCart.Infrastructure.Pages;
using ShoppingCart.Infrastructure.Utilites;

namespace ShoppingCart.Tests
{
    public class ContactInfoTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            AddProductToCart(SkuId.DevCraftUi);
            OrderPage.ContinueAsGuestButton.Click();
            ContactInfoPage.SameAsBillingCheckbox.Click();
        }

        [Test]
        public void CorrectReviewOrderPageInformation_When_FillAllContactInfoFields()
        {
            var billingInformation = InfoPageFactory.CreateBillingInformation();
            var licenseHolderInformation = InfoPageFactory.CreateLicenseInformation();

            ContactInfoPage.FillBillingInformation(billingInformation);
            ContactInfoPage.FillLicenseInformation(licenseHolderInformation);
            ContactInfoPage.ContinueButton.Click();

            Assert.Multiple(() =>
            {
                ReviewOrderPage.AssertBillingInformationIsCorrect(billingInformation);
                ReviewOrderPage.AssertLicenseHolderInformationIsCorrect(licenseHolderInformation);
            });
        }

        [Test]
        public void VatIfFieldEnabled_When_FillCountryBulgaria()
        {
            ContactInfoPage.FillBillingInformation(new BillingInformation { Country = "Bulgaria" });

            Assert.That(ContactInfoPage.EuropeanVatId.Enabled, Is.True, "The field EuropeanVatId is not enabled when Bulgaria is chosen as a country");
        }

        [Test]
        public void CorrectEmailFieldValidations_When_FillInvalidEmail()
        {
            ContactInfoPage.FillAllFormFields(
                new BillingInformation { Email = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Email) },
                new LicenseHolderInformation { Email = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Email) });

            Assert.Multiple(() =>
            {
                Assert.That(ContactInfoPage.EmailBillingError.Displayed, Is.True, "Email Billing field validation not correct");
                Assert.That(ContactInfoPage.EmailLicenseError.Displayed, Is.True, "Email License field validation not correct");
            });
        }

        [Test]
        public void CorrectEmailFieldValidations_When_FillTooLongEmail()
        {
            var billingInformation = $"{RandomGenerator.GenerateString(MaxLengthValidations.EmailMaxLength - 7)}@test.com";
            var licenseHolderInformation = $"{RandomGenerator.GenerateString(MaxLengthValidations.EmailMaxLength - 7)}@test.com";

            ContactInfoPage.FillAllFormFields(
                new BillingInformation { Email = billingInformation },
                new LicenseHolderInformation { Email = licenseHolderInformation });

            var billingInformationUpdated = ContactInfoPage.ExtractBillingInformationFields();
            var licenseHolderInformationUpdated = ContactInfoPage.ExtractLicenseInformationFields();

            ContactInfoPage.AssertAllFieldsNotExceedMaxLength(billingInformationUpdated, licenseHolderInformationUpdated);
        }

        [Test]
        public void CorrectCompanyFieldValidations_When_FillInvalidCompanyName()
        {
            ContactInfoPage.FillAllFormFields(
                new BillingInformation { Company = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Company) },
                new LicenseHolderInformation { Company = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Company) });

            Assert.Multiple(() =>
            {
                Assert.That(ContactInfoPage.CompanyBillingError.Displayed, Is.True, "Company Billing field validation not correct");
                Assert.That(ContactInfoPage.CompanyLicenseError.Displayed, Is.True, "Company License field validation not correct");
            });
        }

        [Test]
        public void CorrectCompanyFieldValidations_When_FillTooLongCompanyName()
        {
            var billingInformation = RandomGenerator.GenerateString(MaxLengthValidations.CompanyMaxLength + 1);
            var licenseHolderInformation = RandomGenerator.GenerateString(MaxLengthValidations.CompanyMaxLength + 1);

            ContactInfoPage.FillAllFormFields(
                new BillingInformation { Company = billingInformation },
                new LicenseHolderInformation { Company = licenseHolderInformation });

            var billingInformationUpdated = ContactInfoPage.ExtractBillingInformationFields();
            var licenseHolderInformationUpdated = ContactInfoPage.ExtractLicenseInformationFields();

            ContactInfoPage.AssertAllFieldsNotExceedMaxLength(billingInformationUpdated, licenseHolderInformationUpdated);
        }

        [Test]
        public void CorrectMaxLengthValidations_When_FillFieldsLongerThanAllowed()
        {
            var billingInformation = InfoPageFactory.CreateBillingInformationOverMaxLength();
            var licenseHolderInformation = InfoPageFactory.CreateLicenseInformationOverMaxLength();

            ContactInfoPage.FillAllFormFields(billingInformation, licenseHolderInformation);            
            var billingInformationUpdated = ContactInfoPage.ExtractBillingInformationFields();
            var licenseHolderInformationUpdated = ContactInfoPage.ExtractLicenseInformationFields();

            ContactInfoPage.AssertAllFieldsNotExceedMaxLength(billingInformationUpdated, licenseHolderInformationUpdated);
        }

        [Test]
        public void CorrectValidationMessages_When_FillInvalidCharacters()
        {
            var billingInformation = InfoPageFactory.CreateBillingInformationInvalidCharacters();
            var licenseHolderInformation = InfoPageFactory.CreateLicenseInformationInvalidCharacters();

            ContactInfoPage.FillAllFormFields(billingInformation, licenseHolderInformation);

            ContactInfoPage.AssertInvalidFieldValidationMessage();
        }
    }
}
