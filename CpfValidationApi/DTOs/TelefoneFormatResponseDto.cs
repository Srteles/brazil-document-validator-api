namespace CpfValidationApi.DTOs;

public class TelefoneFormatResponseDto
{
    public string TelefoneOriginal { get; set; } = string.Empty;
    public string TelefoneSemMascara { get; set; } = string.Empty;
    public string TelefoneFormatado { get; set; } = string.Empty;
}