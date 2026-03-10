namespace CpfValidationApi.DTOs;

public class TelefoneValidationResponseDto
{
    public string TelefoneInformado { get; set; } = string.Empty;
    public string TelefoneSemMascara { get; set; } = string.Empty;
    public bool Valido { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}