using System.Text.RegularExpressions;
using System.Text;

namespace ShoppingCart.Infrastructure.Utilites;

public static class RandomGenerator
{
    private static Random _random = new Random();

    internal static int GenerateInt(int minValue = 100, int maxValue = 9999)
    {
        return _random.Next(minValue, maxValue);
    }

    public static string GenerateString(int length = 5)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        Random random = new Random();
        char[] stringChars = new char[length];

        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }

    public static string GenerateNotAllowedString(string regexPattern)
    {
        if (string.IsNullOrEmpty(regexPattern))
        {
            throw new ArgumentException("Regex pattern cannot be null or empty.");
        }

        const string allCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+[]{}|;:'\",.<>?/\\`~ ";
        Random random = new Random();
        string notAllowedString;

        // Generate random strings until one does not match the regex
        do
        {
            int length = random.Next(7, 15);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(allCharacters[random.Next(allCharacters.Length)]);
            }

            notAllowedString = sb.ToString();
        }
        while (Regex.IsMatch(notAllowedString, regexPattern));

        return notAllowedString;
    }
}
