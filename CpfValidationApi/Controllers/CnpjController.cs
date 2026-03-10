using CpfValidationApi.DTOs;
using CpfValidationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CpfValidationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CnpjController : ControllerBase
{
    private readonly ICnpjService _cnpjService;

    public CnpjController(ICnpjService cnpjService)
    {
        _cnpjService = cnpjService;
    }

    [HttpPost("validate")]
    public ActionResult<CnpjValidationResponseDto> Validate([FromBody] CnpjRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Cnpj))
        {
            return BadRequest(new
            {
                mensagem = "O CNPJ deve ser informado."
            });
        }

        string cleanCnpj = _cnpjService.RemoveMask(request.Cnpj);

        if (cleanCnpj.Length != 14)
        {
            return BadRequest(new
            {
                mensagem = "O CNPJ deve conter 14 dígitos."
            });
        }

        bool isValid = _cnpjService.IsValid(request.Cnpj);

        var response = new CnpjValidationResponseDto
        {
            CnpjInformado = request.Cnpj,
            CnpjSemMascara = cleanCnpj,
            Valido = isValid,
            Mensagem = isValid ? "CNPJ válido." : "CNPJ inválido."
        };

        return Ok(response);
    }

    [HttpPost("format")]
    public ActionResult<CnpjFormatResponseDto> Format([FromBody] CnpjRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Cnpj))
        {
            return BadRequest(new
            {
                mensagem = "O CNPJ deve ser informado."
            });
        }

        string cleanCnpj = _cnpjService.RemoveMask(request.Cnpj);

        if (cleanCnpj.Length != 14)
        {
            return BadRequest(new
            {
                mensagem = "O CNPJ deve conter 14 dígitos."
            });
        }

        var response = new CnpjFormatResponseDto
        {
            CnpjOriginal = request.Cnpj,
            CnpjSemMascara = cleanCnpj,
            CnpjFormatado = _cnpjService.Format(request.Cnpj)
        };

        return Ok(response);
    }

    [HttpGet("generate")]
    public ActionResult<object> Generate()
    {
        string generatedCnpj = _cnpjService.Generate();

        return Ok(new
        {
            cnpj = generatedCnpj,
            cnpjFormatado = _cnpjService.Format(generatedCnpj)
        });
    }
}