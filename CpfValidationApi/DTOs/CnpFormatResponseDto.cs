namespace CpfValidationApi.DTOs;

public class CnpjFormatResponseDto
{
    public string CnpjOriginal { get; set; } = string.Empty;
    public string CnpjSemMascara { get; set; } = string.Empty;
    public string CnpjFormatado { get; set; } = string.Empty;
}