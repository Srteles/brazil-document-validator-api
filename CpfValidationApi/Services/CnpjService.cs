using System.Text.RegularExpressions;

namespace CpfValidationApi.Services;

public class CnpjService : ICnpjService
{
    public bool IsValid(string cnpj)
    {
        cnpj = RemoveMask(cnpj);

        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        if (cnpj.Length != 14)
            return false;

        if (!cnpj.All(char.IsDigit))
            return false;

        if (cnpj.Distinct().Count() == 1)
            return false;

        int[] numbers = cnpj.Select(c => c - '0').ToArray();

        int firstDigit = CalculateDigit(numbers.Take(12).ToArray(), new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
        int secondDigit = CalculateDigit(numbers.Take(13).ToArray(), new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

        return numbers[12] == firstDigit && numbers[13] == secondDigit;
    }

    public string RemoveMask(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return string.Empty;

        return Regex.Replace(cnpj, @"\D", "");
    }

    public string Format(string cnpj)
    {
        cnpj = RemoveMask(cnpj);

        if (cnpj.Length != 14 || !cnpj.All(char.IsDigit))
            return cnpj;

        return $"{cnpj[..2]}.{cnpj[2..5]}.{cnpj[5..8]}/{cnpj[8..12]}-{cnpj[12..14]}";
    }

    public string Generate()
    {
        Random random = new();

        int[] baseDigits = new int[12];
        for (int i = 0; i < 12; i++)
        {
            baseDigits[i] = random.Next(0, 10);
        }

        if (baseDigits.Distinct().Count() == 1)
        {
            baseDigits[11] = (baseDigits[11] + 1) % 10;
        }

        int firstDigit = CalculateDigit(baseDigits, new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
        int secondDigit = CalculateDigit(baseDigits.Append(firstDigit).ToArray(), new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

        return string.Concat(baseDigits) + firstDigit + secondDigit;
    }

    private static int CalculateDigit(int[] digits, int[] weights)
    {
        int sum = 0;

        for (int i = 0; i < digits.Length; i++)
        {
            sum += digits[i] * weights[i];
        }

        int remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}