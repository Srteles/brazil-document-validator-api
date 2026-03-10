using System.Net.Mail;

namespace CpfValidationApi.Services;

public class EmailService : IEmailService
{
    public bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var mailAddress = new MailAddress(email);
            return mailAddress.Address == email.Trim();
        }
        catch
        {
            return false;
        }
    }
}