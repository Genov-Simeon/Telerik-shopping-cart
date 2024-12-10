using System.Globalization;
using System.Text.RegularExpressions;

namespace ShoppingCart.Infrastructure.Utilities;

public static class StringExtensions
{
    public static decimal ExctractPrice(this string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Input string cannot be null or empty.");

        string numericPart = Regex.Match(input, @"-?\d+(,\d{3})*(\.\d+)?").Value;

        if (string.IsNullOrEmpty(numericPart))
            throw new FormatException("Input string does not contain a valid numeric format.");

        numericPart = numericPart.Replace(",", "");

        if (decimal.TryParse(numericPart, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result))
        {
            return result;
        }
        else
        {
            throw new FormatException("Failed to parse the numeric part of the string.");
        }
    }
}
