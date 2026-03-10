namespace CpfValidationApi.DTOs;

public class CepFormatResponseDto
{
    public string CepOriginal { get; set; } = string.Empty;
    public string CepSemMascara { get; set; } = string.Empty;
    public string CepFormatado { get; set; } = string.Empty;
}