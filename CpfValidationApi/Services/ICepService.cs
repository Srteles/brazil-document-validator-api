namespace CpfValidationApi.Services;

public interface ICepService
{
    bool IsValid(string cep);
    string RemoveMask(string cep);
    string Format(string cep);
    string Generate();
}