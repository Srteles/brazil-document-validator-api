using CpfValidationApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICpfService, CpfService>();
builder.Services.AddScoped<ICnpjService, CnpjService>();
builder.Services.AddScoped<ICepService, CepService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITelefoneService, TelefoneService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();