namespace CpfValidationApi.Services;

public interface ITelefoneService
{
    bool IsValid(string telefone);
    string RemoveMask(string telefone);
    string Format(string telefone);
}