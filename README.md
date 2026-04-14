# 📌 Brazil Document Validator API

API desenvolvida em C# com ASP.NET Core para validação, formatação e geração de documentos brasileiros, como CPF, CNPJ, CEP, e-mail e telefone.

O projeto tem como foco o desenvolvimento back-end, aplicando boas práticas de arquitetura, organização de código e testes automatizados.

---

## 🚀 Tecnologias utilizadas

- C# / .NET
- ASP.NET Core Web API
- xUnit (testes automatizados)
- Swagger (documentação interativa)
- Arquitetura em camadas (Controllers, Services, DTOs)

---

## 🧱 Estrutura do projeto

```text
BrazilDocumentValidator
├── CpfValidationApi
│   ├── Controllers
│   ├── Services
│   ├── DTOs
│   └── Program.cs
├── CpfValidationApi.Tests
└── README.md
```

---


---

## 📡 Endpoints disponíveis

### CPF
- `POST /api/Cpf/validate`
- `POST /api/Cpf/format`
- `GET /api/Cpf/generate`

### CNPJ
- `POST /api/Cnpj/validate`
- `POST /api/Cnpj/format`
- `GET /api/Cnpj/generate`

### CEP
- `POST /api/Cep/validate`
- `POST /api/Cep/format`
- `GET /api/Cep/generate`

### Email
- `POST /api/Email/validate`

### Telefone
- `POST /api/Telefone/validate`
- `POST /api/Telefone/format`

---

## 🔎 Exemplo de uso

### Validação de CPF

**Request**
```json
{
  "cpf": "12345678909"
}

Response

{
  "isValid": true
}

## ⚙️ Como executar o projeto

```bash
git clone https://github.com/Srteles/brazil-document-validator-api.git
cd brazil-document-validator-api
dotnet restore
dotnet run

Após iniciar o projeto, a documentação interativa estará disponível em:

http://localhost:5011/swagger

O Swagger permite testar todos os endpoints diretamente pelo navegador.

Executar testes

Para rodar os testes automatizados:

dotnet test


Autor

Lucas Silva Teles
Analista de Suporte de TI | Desenvolvedor Back-end (C# / .NET)
