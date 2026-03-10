using Xunit;
using CpfValidationApi.Services;

namespace CpfValidationApi.Tests.Services;

public class EmailServiceTests
{
    private readonly EmailService _emailService;

    public EmailServiceTests()
    {
        _emailService = new EmailService();
    }

    [Theory]
    [InlineData("teste@email.com")]
    [InlineData("lucas.silva@empresa.com.br")]
    [InlineData("usuario123@gmail.com")]
    public void IsValid_ShouldReturnTrue_WhenEmailIsValid(string email)
    {
        bool result = _emailService.IsValid(email);

        Assert.True(result);
    }

    [Theory]
    [InlineData("teste@")]
    [InlineData("abc")]
    [InlineData("")]
    public void IsValid_ShouldReturnFalse_WhenEmailIsInvalid(string email)
    {
        bool result = _emailService.IsValid(email);

        Assert.False(result);
    }
}