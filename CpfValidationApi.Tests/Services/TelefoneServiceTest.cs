using Xunit;
using CpfValidationApi.Services;

namespace CpfValidationApi.Tests.Services;

public class TelefoneServiceTests
{
    private readonly TelefoneService _telefoneService;

    public TelefoneServiceTests()
    {
        _telefoneService = new TelefoneService();
    }

    [Theory]
    [InlineData("(11) 91234-5678")]
    [InlineData("11912345678")]
    [InlineData("(11) 1234-5678")]
    [InlineData("1112345678")]
    public void IsValid_ShouldReturnTrue_WhenTelefoneIsValid(string telefone)
    {
        bool result = _telefoneService.IsValid(telefone);

        Assert.True(result);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("abc")]
    [InlineData("")]
    public void IsValid_ShouldReturnFalse_WhenTelefoneIsInvalid(string telefone)
    {
        bool result = _telefoneService.IsValid(telefone);

        Assert.False(result);
    }

    [Fact]
    public void RemoveMask_ShouldReturnOnlyNumbers()
    {
        string result = _telefoneService.RemoveMask("(11) 91234-5678");

        Assert.Equal("11912345678", result);
    }

    [Fact]
    public void Format_ShouldReturnFormattedTelefone_WhenValid()
    {
        string result = _telefoneService.Format("11912345678");

        Assert.Equal("(11) 91234-5678", result);
    }
}