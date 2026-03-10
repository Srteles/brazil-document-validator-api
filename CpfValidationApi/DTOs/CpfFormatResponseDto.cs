namespace CpfValidationApi.DTOs;

public class CpfFormatResponseDto
{
    public string CpfOriginal { get; set; } = string.Empty;
    public string CpfSemMascara { get; set; } = string.Empty;
    public string CpfFormatado { get; set; } = string.Empty;
}