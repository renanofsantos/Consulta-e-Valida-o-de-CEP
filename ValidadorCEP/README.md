# ValidadorCEP

API REST em C#/ASP.NET Core para consulta de endereços a partir de um CEP, com integração à [ViaCEP](https://viacep.com.br/) e uma interface web para consulta visual.

Projeto de estudo focado em: consumo de API externa, injeção de dependência, arquitetura em camadas (Controller → Service) e Razor Pages.

## Funcionalidades

- Consulta de endereço (rua, bairro, cidade, estado) a partir de um CEP
- Endpoint de API REST (`GET /api/Endereco/{cep}`)
- Interface web (Razor Pages) para consulta visual, sem precisar de ferramentas externas
- Tratamento de erros para CEP inválido ou inexistente
- Documentação automática via Swagger

## Tecnologias

- C# / .NET 8
- ASP.NET Core (Web API + Razor Pages)
- Injeção de dependência (`IHttpClientFactory`)
- `System.Text.Json` para deserialização
- Swagger / OpenAPI
- [ViaCEP](https://viacep.com.br/) como fonte de dados de CEP

## Arquitetura

```
ValidadorCEP/
├── Controllers/        # Endpoints da API (JSON)
│   └── EnderecoController.cs
├── Models/              # DTOs — formato dos dados da ViaCEP
│   └── EnderecoViaCep.cs
├── Services/            # Lógica de integração com a API externa
│   ├── IEnderecoService.cs
│   └── EnderecoService.cs
├── Pages/               # Interface web (Razor Pages)
│   ├── Index.cshtml
│   └── Index.cshtml.cs
└── Program.cs           # Configuração e injeção de dependência
```

O fluxo segue uma separação clara de responsabilidades:

**Controller / Razor Page** → recebe a requisição → chama o **Service** → **Service** consulta a **ViaCEP** via `HttpClient` → deserializa o JSON → devolve o resultado.

## Como rodar

```bash
git clone https://github.com/renanofsantos/validador-cep.git
cd ValidadorCEP
dotnet restore
dotnet run
```

Depois de rodar, acesse:
- Interface web: `https://localhost:{porta}/`
- Swagger (documentação da API): `https://localhost:{porta}/swagger`

## Endpoint da API

**GET** `/api/Endereco/{cep}`

Exemplo:
```
GET /api/Endereco/01001000
```

Resposta (200 OK):
```json
{
  "cep": "01001-000",
  "logradouro": "Praça da Sé",
  "complemento": "lado ímpar",
  "bairro": "Sé",
  "localidade": "São Paulo",
  "uf": "SP",
  "regiao": "Sudeste",
  "ibge": "3550308",
  "ddd": "11"
}
```

Se o CEP for inválido ou não for encontrado, a API responde com **400 Bad Request**.

## Autor

Desenvolvido por **Renan Santos**
