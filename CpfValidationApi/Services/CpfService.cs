using System.Text.RegularExpressions;

namespace CpfValidationApi.Services;

public class CpfService : ICpfService
{
    public bool IsValid(string cpf)
    {
        cpf = RemoveMask(cpf);

        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        if (cpf.Length != 11)
            return false;

        if (!cpf.All(char.IsDigit))
            return false;

        if (cpf.Distinct().Count() == 1)
            return false;

        int[] numbers = cpf.Select(c => c - '0').ToArray();

        int firstDigit = CalculateDigit(numbers.Take(9).ToArray(), 10);
        int secondDigit = CalculateDigit(numbers.Take(10).ToArray(), 11);

        return numbers[9] == firstDigit && numbers[10] == secondDigit;
    }

    public string RemoveMask(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return string.Empty;

        return Regex.Replace(cpf, @"\D", "");
    }

    public string Format(string cpf)
    {
        cpf = RemoveMask(cpf);

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            return cpf;

        return $"{cpf[..3]}.{cpf[3..6]}.{cpf[6..9]}-{cpf[9..11]}";
    }

    public string Generate()
    {
        Random random = new();

        int[] baseDigits = new int[9];
        for (int i = 0; i < 9; i++)
        {
            baseDigits[i] = random.Next(0, 10);
        }

        if (baseDigits.Distinct().Count() == 1)
        {
            baseDigits[8] = (baseDigits[8] + 1) % 10;
        }

        int firstDigit = CalculateDigit(baseDigits, 10);
        int secondDigit = CalculateDigit(baseDigits.Append(firstDigit).ToArray(), 11);

        return string.Concat(baseDigits) + firstDigit + secondDigit;
    }

    private static int CalculateDigit(int[] digits, int weightStart)
    {
        int sum = 0;
        int weight = weightStart;

        foreach (var digit in digits)
        {
            sum += digit * weight;
            weight--;
        }

        int remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}