namespace CpfValidationApi.Services;

public interface IEmailService
{
    bool IsValid(string email);
}