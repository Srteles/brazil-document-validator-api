namespace CpfValidationApi.DTOs;

public class CnpjValidationResponseDto
{
    public string CnpjInformado { get; set; } = string.Empty;
    public string CnpjSemMascara { get; set; } = string.Empty;
    public bool Valido { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}