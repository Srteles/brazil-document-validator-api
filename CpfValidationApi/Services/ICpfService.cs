namespace CpfValidationApi.Services;

public interface ICpfService
{
    bool IsValid(string cpf);
    string RemoveMask(string cpf);
    string Format(string cpf);
    string Generate();
}