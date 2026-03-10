using CpfValidationApi.DTOs;
using CpfValidationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CpfValidationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CepController : ControllerBase
{
    private readonly ICepService _cepService;

    public CepController(ICepService cepService)
    {
        _cepService = cepService;
    }

    [HttpPost("validate")]
    public ActionResult<CepValidationResponseDto> Validate([FromBody] CepRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Cep))
        {
            return BadRequest(new { mensagem = "O CEP deve ser informado." });
        }

        string cleanCep = _cepService.RemoveMask(request.Cep);

        if (cleanCep.Length != 8)
        {
            return BadRequest(new { mensagem = "O CEP deve conter 8 dígitos." });
        }

        bool isValid = _cepService.IsValid(request.Cep);

        var response = new CepValidationResponseDto
        {
            CepInformado = request.Cep,
            CepSemMascara = cleanCep,
            Valido = isValid,
            Mensagem = isValid ? "CEP válido." : "CEP inválido."
        };

        return Ok(response);
    }

    [HttpPost("format")]
    public ActionResult<CepFormatResponseDto> Format([FromBody] CepRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Cep))
        {
            return BadRequest(new { mensagem = "O CEP deve ser informado." });
        }

        string cleanCep = _cepService.RemoveMask(request.Cep);

        if (cleanCep.Length != 8)
        {
            return BadRequest(new { mensagem = "O CEP deve conter 8 dígitos." });
        }

        var response = new CepFormatResponseDto
        {
            CepOriginal = request.Cep,
            CepSemMascara = cleanCep,
            CepFormatado = _cepService.Format(request.Cep)
        };

        return Ok(response);
    }

    [HttpGet("generate")]
    public ActionResult<object> Generate()
    {
        string generatedCep = _cepService.Generate();

        return Ok(new
        {
            cep = generatedCep,
            cepFormatado = _cepService.Format(generatedCep)
        });
    }
}