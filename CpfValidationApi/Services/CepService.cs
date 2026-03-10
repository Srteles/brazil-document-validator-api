using System.Text.RegularExpressions;

namespace CpfValidationApi.Services;

public class CepService : ICepService
{
    public bool IsValid(string cep)
    {
        cep = RemoveMask(cep);

        if (string.IsNullOrWhiteSpace(cep))
            return false;

        if (cep.Length != 8)
            return false;

        if (!cep.All(char.IsDigit))
            return false;

        return true;
    }

    public string RemoveMask(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep))
            return string.Empty;

        return Regex.Replace(cep, @"\D", "");
    }

    public string Format(string cep)
    {
        cep = RemoveMask(cep);

        if (cep.Length != 8 || !cep.All(char.IsDigit))
            return cep;

        return $"{cep[..5]}-{cep[5..8]}";
    }

    public string Generate()
    {
        Random random = new();

        string cep = string.Concat(Enumerable.Range(0, 8)
            .Select(_ => random.Next(0, 10).ToString()));

        return cep;
    }
}