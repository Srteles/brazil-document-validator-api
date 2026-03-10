using CpfValidationApi.DTOs;
using CpfValidationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CpfValidationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("validate")]
    public ActionResult<EmailValidationResponseDto> Validate([FromBody] EmailRequestDto request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Email))
        {
            return BadRequest(new { mensagem = "O e-mail deve ser informado." });
        }

        bool isValid = _emailService.IsValid(request.Email);

        var response = new EmailValidationResponseDto
        {
            EmailInformado = request.Email,
            Valido = isValid,
            Mensagem = isValid ? "E-mail válido." : "E-mail inválido."
        };

        return Ok(response);
    }
}