namespace CpfValidationApi.DTOs;

public class CpfValidationResponseDto
{
    public string CpfInformado { get; set; } = string.Empty;
    public string CpfSemMascara { get; set; } = string.Empty;
    public bool Valido { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}