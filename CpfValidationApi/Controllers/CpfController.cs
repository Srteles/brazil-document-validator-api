using CpfValidationApi.DTOs;
using CpfValidationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CpfValidationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CpfController : ControllerBase
{
    private readonly ICpfService _cpfService;

    public CpfController(ICpfService cpfService)
    {
        _cpfService = cpfService;
    }

    [HttpPost("validate")]
    public ActionResult<CpfValidationResponseDto> Validate([FromBody] CpfRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Cpf))
        {
            return BadRequest(new
            {
                mensagem = "O CPF deve ser informado."
            });
        }

        string cleanCpf = _cpfService.RemoveMask(request.Cpf);

        if (cleanCpf.Length != 11)
        {
            return BadRequest(new
            {
                mensagem = "O CPF deve conter 11 dígitos."
            });
        }

        bool isValid = _cpfService.IsValid(request.Cpf);

        var response = new CpfValidationResponseDto
        {
            CpfInformado = request.Cpf,
            CpfSemMascara = cleanCpf,
            Valido = isValid,
            Mensagem = isValid ? "CPF válido." : "CPF inválido."
        };

        return Ok(response);
    }

    [HttpPost("format")]
    public ActionResult<CpfFormatResponseDto> Format([FromBody] CpfRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Cpf))
        {
            return BadRequest(new
            {
                mensagem = "O CPF deve ser informado."
            });
        }

        string cleanCpf = _cpfService.RemoveMask(request.Cpf);

        if (cleanCpf.Length != 11)
        {
            return BadRequest(new
            {
                mensagem = "O CPF deve conter 11 dígitos."
            });
        }

        var response = new CpfFormatResponseDto
        {
            CpfOriginal = request.Cpf,
            CpfSemMascara = cleanCpf,
            CpfFormatado = _cpfService.Format(request.Cpf)
        };

        return Ok(response);
    }

    [HttpGet("generate")]
    public ActionResult<object> Generate()
    {
        string generatedCpf = _cpfService.Generate();

        return Ok(new
        {
            cpf = generatedCpf,
            cpfFormatado = _cpfService.Format(generatedCpf)
        });
    }
}