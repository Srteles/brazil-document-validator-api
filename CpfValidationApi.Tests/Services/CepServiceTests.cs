using Xunit;
using CpfValidationApi.Services;

namespace CpfValidationApi.Tests.Services;

public class CepServiceTests
{
    private readonly CepService _cepService;

    public CepServiceTests()
    {
        _cepService = new CepService();
    }

    [Theory]
    [InlineData("12345-678")]
    [InlineData("12345678")]
    public void IsValid_ShouldReturnTrue_WhenCepIsValid(string cep)
    {
        bool result = _cepService.IsValid(cep);

        Assert.True(result);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("abc")]
    [InlineData("")]
    public void IsValid_ShouldReturnFalse_WhenCepIsInvalid(string cep)
    {
        bool result = _cepService.IsValid(cep);

        Assert.False(result);
    }

    [Fact]
    public void RemoveMask_ShouldReturnOnlyNumbers()
    {
        string result = _cepService.RemoveMask("12345-678");

        Assert.Equal("12345678", result);
    }

    [Fact]
    public void Format_ShouldReturnMaskedCep_WhenCepIsValid()
    {
        string result = _cepService.Format("12345678");

        Assert.Equal("12345-678", result);
    }

    [Fact]
    public void Generate_ShouldReturnValidCep()
    {
        string cep = _cepService.Generate();

        bool result = _cepService.IsValid(cep);

        Assert.True(result);
    }
}