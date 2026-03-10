using System.Text.RegularExpressions;

namespace CpfValidationApi.Services;

public class TelefoneService : ITelefoneService
{
    public bool IsValid(string telefone)
    {
        telefone = RemoveMask(telefone);

        if (string.IsNullOrWhiteSpace(telefone))
            return false;

        if (!telefone.All(char.IsDigit))
            return false;

        return telefone.Length == 10 || telefone.Length == 11;
    }

    public string RemoveMask(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone))
            return string.Empty;

        return Regex.Replace(telefone, @"\D", "");
    }

    public string Format(string telefone)
    {
        telefone = RemoveMask(telefone);

        if (!telefone.All(char.IsDigit))
            return telefone;

        if (telefone.Length == 11)
        {
            return $"({telefone[..2]}) {telefone[2..7]}-{telefone[7..11]}";
        }

        if (telefone.Length == 10)
        {
            return $"({telefone[..2]}) {telefone[2..6]}-{telefone[6..10]}";
        }

        return telefone;
    }
}