namespace CpfValidationApi.Services;

public interface ICnpjService
{
    bool IsValid(string cnpj);
    string RemoveMask(string cnpj);
    string Format(string cnpj);
    string Generate();
}