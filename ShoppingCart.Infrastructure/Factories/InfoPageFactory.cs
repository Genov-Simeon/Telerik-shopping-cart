using ShoppingCart.Infrastructure.Models;
using ShoppingCart.Infrastructure.Pages;
using ShoppingCart.Infrastructure.Utilites;
using System.ComponentModel;

namespace ShoppingCart.Infrastructure.Factories
{
    public static class InfoPageFactory
    {

        public static BillingInformation CreateBillingInformation()
        {
            return new BillingInformation
            {
                FirstName = RandomGenerator.GenerateString(8),
                LastName = RandomGenerator.GenerateString(10),
                Email = $"{RandomGenerator.GenerateString(5)}@example.com",
                Company = $"{RandomGenerator.GenerateString(10)} Corp",
                Phone = $"{RandomGenerator.GenerateInt(100, 999)}-{RandomGenerator.GenerateInt(100, 999)}-{RandomGenerator.GenerateInt(1000, 9999)}",
                Address = $"{RandomGenerator.GenerateInt(1, 9999)} {RandomGenerator.GenerateString(12)} Street",
                Country = "Bulgaria",
                City = RandomGenerator.GenerateString(7),
                ZipOrPostalCode = RandomGenerator.GenerateInt(10000, 99999).ToString(),
            };
        }

        public static BillingInformation CreateBillingInformationOverMaxLength()
        {
            return new BillingInformation
            {
                FirstName = RandomGenerator.GenerateString(MaxLengthValidations.FirstNameMaxLength + 1),
                LastName = RandomGenerator.GenerateString(MaxLengthValidations.LastNameMaxLength + 1),
                Email = $"{RandomGenerator.GenerateString(MaxLengthValidations.EmailMaxLength - 11)}@example.com",
                Company = RandomGenerator.GenerateString(MaxLengthValidations.CompanyMaxLength + 1),
                Phone = RandomGenerator.GenerateString(MaxLengthValidations.PhoneMaxLength + 1),
                Address = RandomGenerator.GenerateString(MaxLengthValidations.AddressMaxLength + 1),
                City = RandomGenerator.GenerateString(MaxLengthValidations.CityMaxLength + 1),
                ZipOrPostalCode = RandomGenerator.GenerateString(MaxLengthValidations.ZipPostalCodeMaxLength + 1)
            };
        }

        public static BillingInformation CreateBillingInformationInvalidCharacters()
        {
            return new BillingInformation
            {
                FirstName = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.FirstName),
                LastName = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.LastName),
                Email = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Email),
                Company = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Company),
                Phone = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Phone),
                Address = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Address),
                City = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.City),
                ZipOrPostalCode = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.ZipOrPostalCode),
            };
        }

        public static LicenseHolderInformation CreateLicenseInformation()
        {

            return new LicenseHolderInformation
            {
                FirstName = RandomGenerator.GenerateString(8),
                LastName = RandomGenerator.GenerateString(10),
                Email = $"{RandomGenerator.GenerateString(5)}@example.com",
                Company = $"{RandomGenerator.GenerateString(10)} Corp",
                Address = $"{RandomGenerator.GenerateInt(1, 9999)} {RandomGenerator.GenerateString(12)} Street",
                Country = "Bulgaria",
                City = RandomGenerator.GenerateString(7),
                ZipOrPostalCode = RandomGenerator.GenerateInt(10000, 99999).ToString(),
            };
        }

        public static LicenseHolderInformation CreateLicenseInformationOverMaxLength()
        {
            return new LicenseHolderInformation
            {
                FirstName = RandomGenerator.GenerateString(MaxLengthValidations.FirstNameMaxLength + 1),
                LastName = RandomGenerator.GenerateString(MaxLengthValidations.LastNameMaxLength + 1),
                Email = $"{RandomGenerator.GenerateString(MaxLengthValidations.EmailMaxLength - 11)}@example.com",
                Company = RandomGenerator.GenerateString(MaxLengthValidations.CompanyMaxLength + 1),
                Address = RandomGenerator.GenerateString(MaxLengthValidations.AddressMaxLength + 1),
                City = RandomGenerator.GenerateString(MaxLengthValidations.CityMaxLength + 1),
                ZipOrPostalCode = RandomGenerator.GenerateString(MaxLengthValidations.ZipPostalCodeMaxLength + 1)
            };
        }

        public static LicenseHolderInformation CreateLicenseInformationInvalidCharacters()
        {
            return new LicenseHolderInformation
            {
                FirstName = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.FirstName),
                LastName = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.LastName),
                Email = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Email),
                Company = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Company),
                Address = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.Address),
                City = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.City),
                ZipOrPostalCode = RandomGenerator.GenerateNotAllowedString(RegexRestrictions.ZipOrPostalCode),
            };
        }
    }
}
