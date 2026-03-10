namespace CpfValidationApi.DTOs;

public class EmailValidationResponseDto
{
    public string EmailInformado { get; set; } = string.Empty;
    public bool Valido { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}