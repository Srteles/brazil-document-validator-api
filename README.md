Brazil Document Validator API

API REST desenvolvida em ASP.NET Core para validação, geração e formatação de dados comuns utilizados em sistemas brasileiros, como CPF, CNPJ, CEP, Email e Telefone.

O projeto foi desenvolvido com foco em boas práticas de backend, arquitetura em camadas e testes automatizados.

Funcionalidades

 A API oferece validação e manipulação dos seguintes dados:

- Validação de CPF

- Formatação e geração de CPF

- Validação de CNPJ

- Formatação e geração de CNPJ

- Validação de CEP

- Formatação de CEP

- Validação de Email

- Validação e formatação de Telefone

Todos os endpoints podem ser testados facilmente através do Swagger UI.

Tecnologias utilizadas

- .NET 9

- ASP.NET Core Web API

- Swagger / OpenAPI

- xUnit (Testes unitários)

Arquitetura em camadas (Controllers, Services, DTOs)

Estrutura do projeto
BrazilDocumentValidator
│
├── CpfValidationApi
│   ├── Controllers
│   ├── Services
│   ├── DTOs
│   └── Program.cs
│
├── CpfValidationApi.Tests
│
├── README.md
└── .gitignore
Endpoints disponíveis

CPF
    POST /api/Cpf/validate
    POST /api/Cpf/format
    GET  /api/Cpf/generate

CNPJ
    POST /api/Cnpj/validate
    POST /api/Cnpj/format
    GET  /api/Cnpj/generate

CEP
    POST /api/Cep/validate
    POST /api/Cep/format
    GET  /api/Cep/generate

Email
    POST /api/Email/validate

Telefone
    POST /api/Telefone/validate
    POST /api/Telefone/format

Como executar o projeto

Clone o repositório:

git clone https://github.com/SEU-USUARIO/brazil-document-validator-api.git

Entre na pasta do projeto:

cd brazil-document-validator-api

Restaure os pacotes:

dotnet restore

Execute o projeto:

dotnet run
Documentação da API

Após iniciar o projeto, a documentação interativa estará disponível em:

http://localhost:xxxx/swagger

O Swagger permite testar todos os endpoints diretamente pelo navegador.

Executar testes

Para rodar os testes automatizados:

dotnet test

Objetivo do projeto

Este projeto foi desenvolvido como prática de desenvolvimento backend utilizando C# e ASP.NET Core, aplicando conceitos como:

- criação de APIs REST

- organização de regras de negócio

- testes automatizados

- documentação de endpoints

- boas práticas de arquitetura

Autor

Lucas Silva Teles
Analista de Suporte / Desenvolvedor C#