namespace CpfValidationApi.DTOs;

public class CepValidationResponseDto
{
    public string CepInformado { get; set; } = string.Empty;
    public string CepSemMascara { get; set; } = string.Empty;
    public bool Valido { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}