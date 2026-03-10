using CpfValidationApi.DTOs;
using CpfValidationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CpfValidationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelefoneController : ControllerBase
{
    private readonly ITelefoneService _telefoneService;

    public TelefoneController(ITelefoneService telefoneService)
    {
        _telefoneService = telefoneService;
    }

    [HttpPost("validate")]
    public ActionResult<TelefoneValidationResponseDto> Validate([FromBody] TelefoneRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Telefone))
        {
            return BadRequest(new { mensagem = "O telefone deve ser informado." });
        }

        string cleanTelefone = _telefoneService.RemoveMask(request.Telefone);

        if (cleanTelefone.Length != 10 && cleanTelefone.Length != 11)
        {
            return BadRequest(new { mensagem = "O telefone deve conter 10 ou 11 dígitos." });
        }

        bool isValid = _telefoneService.IsValid(request.Telefone);

        var response = new TelefoneValidationResponseDto
        {
            TelefoneInformado = request.Telefone,
            TelefoneSemMascara = cleanTelefone,
            Valido = isValid,
            Mensagem = isValid ? "Telefone válido." : "Telefone inválido."
        };

        return Ok(response);
    }

    [HttpPost("format")]
    public ActionResult<TelefoneFormatResponseDto> Format([FromBody] TelefoneRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Telefone))
        {
            return BadRequest(new { mensagem = "O telefone deve ser informado." });
        }

        string cleanTelefone = _telefoneService.RemoveMask(request.Telefone);

        if (cleanTelefone.Length != 10 && cleanTelefone.Length != 11)
        {
            return BadRequest(new { mensagem = "O telefone deve conter 10 ou 11 dígitos." });
        }

        var response = new TelefoneFormatResponseDto
        {
            TelefoneOriginal = request.Telefone,
            TelefoneSemMascara = cleanTelefone,
            TelefoneFormatado = _telefoneService.Format(request.Telefone)
        };

        return Ok(response);
    }
}