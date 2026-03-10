using Xunit;
using CpfValidationApi.Services;

namespace CpfValidationApi.Tests.Services;

public class CnpjServiceTests
{
    private readonly CnpjService _cnpjService;

    public CnpjServiceTests()
    {
        _cnpjService = new CnpjService();
    }

    [Theory]
    [InlineData("11.444.777/0001-61")]
    [InlineData("11444777000161")]
    public void IsValid_ShouldReturnTrue_WhenCnpjIsValid(string cnpj)
    {
        bool result = _cnpjService.IsValid(cnpj);

        Assert.True(result);
    }

    [Theory]
    [InlineData("11.111.111/1111-11")]
    [InlineData("12345678000100")]
    [InlineData("00000000000000")]
    [InlineData("abc")]
    [InlineData("")]
    public void IsValid_ShouldReturnFalse_WhenCnpjIsInvalid(string cnpj)
    {
        bool result = _cnpjService.IsValid(cnpj);

        Assert.False(result);
    }

    [Fact]
    public void RemoveMask_ShouldReturnOnlyNumbers()
    {
        string result = _cnpjService.RemoveMask("11.444.777/0001-61");

        Assert.Equal("11444777000161", result);
    }

    [Fact]
    public void Format_ShouldReturnMaskedCnpj_WhenCnpjIsValidLength()
    {
        string result = _cnpjService.Format("11444777000161");

        Assert.Equal("11.444.777/0001-61", result);
    }

    [Fact]
    public void Generate_ShouldReturnAValidCnpj()
    {
        string generatedCnpj = _cnpjService.Generate();

        bool result = _cnpjService.IsValid(generatedCnpj);

        Assert.True(result);
    }
}