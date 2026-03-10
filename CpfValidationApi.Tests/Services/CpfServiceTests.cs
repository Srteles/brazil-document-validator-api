using Xunit;
using CpfValidationApi.Services;

namespace CpfValidationApi.Tests.Services;

public class CpfServiceTests
{
    private readonly CpfService _cpfService;

    public CpfServiceTests()
    {
        _cpfService = new CpfService();
    }

    [Theory]
    [InlineData("529.982.247-25")]
    [InlineData("52998224725")]
    public void IsValid_ShouldReturnTrue_WhenCpfIsValid(string cpf)
    {
        bool result = _cpfService.IsValid(cpf);

        Assert.True(result);
    }

    [Theory]
    [InlineData("111.111.111-11")]
    [InlineData("123.456.789-00")]
    [InlineData("00000000000")]
    [InlineData("abc")]
    [InlineData("")]
    public void IsValid_ShouldReturnFalse_WhenCpfIsInvalid(string cpf)
    {
        bool result = _cpfService.IsValid(cpf);

        Assert.False(result);
    }

    [Fact]
    public void RemoveMask_ShouldReturnOnlyNumbers()
    {
        string result = _cpfService.RemoveMask("529.982.247-25");

        Assert.Equal("52998224725", result);
    }

    [Fact]
    public void Format_ShouldReturnMaskedCpf_WhenCpfIsValidLength()
    {
        string result = _cpfService.Format("52998224725");

        Assert.Equal("529.982.247-25", result);
    }

    [Fact]
    public void Generate_ShouldReturnAValidCpf()
    {
        string generatedCpf = _cpfService.Generate();

        bool result = _cpfService.IsValid(generatedCpf);

        Assert.True(result);
    }
}