# EstoqueRoupas

Sistema de gestão de estoque para uma loja de roupas, desenvolvido em .NET 10 com ASP.NET Core Web API, Entity Framework Core e SQL Server.

> O objetivo do projeto é servir como base para estudo de arquitetura, organização de camadas, persistência de dados e desenvolvimento de APIs REST em C#.


[README.md in English 🇺🇸](en-US/README.md)

## Stack tecnológica

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Dependency Injection do ASP.NET Core
- Swagger / OpenAPI

## Arquitetura

O projeto está organizado em camadas para manter a aplicação mais limpa e fácil de evoluir:

| Projeto | Responsabilidade |
| --- | --- |
| EstoqueRoupas.Domain | Entidades e interfaces do domínio |
| EstoqueRoupas.Infrastructure | DbContext, configurações, migrations e serviços |
| EstoqueRoupas.API | Exposição dos endpoints HTTP |


A camada de domínio é o núcleo da aplicação e não depende das outras camadas.

## Estrutura atual do projeto

- Entidade: Produto
- Interface de serviço: IProdutoService
- Implementação: ProdutoService
- Controller: ProdutosController
- Persistência: AppDbContext + Fluent API

## Requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

- .NET 10 SDK
- SQL Server local ou via Docker
- Git

## Configuração do banco

A aplicação usa a connection string definida em `EstoqueRoupas.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1,1433;Database=EstoqueRoupasDb;User Id=sa;Password=SenhaForte@2026;TrustServerCertificate=True;Encrypt=False;"
  }
}
```

Se preferir, você pode subir o SQL Server em Docker com o comando abaixo:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SenhaForte@2026" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

## Como executar

### 1. Restaurar dependências

```bash
dotnet restore
```

### 2. Aplicar as migrations

```bash
dotnet ef database update \
  --project EstoqueRoupas.Infrastructure \
  --startup-project EstoqueRoupas.API
```

### 3. Rodar a API

```bash
dotnet run --project EstoqueRoupas.API
```

A API ficará disponível em:

```text
https://localhost:5125/api/produtos
```

A documentação OpenAPI/Swagger pode ser acessada na rota:

```text
https://localhost:<porta>/openapi/v1.json
```

## Endpoints principais

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | /api/produtos | Lista todos os produtos |
| GET | /api/produtos/{id} | Busca um produto por id |
| POST | /api/produtos | Cria um novo produto |
| PUT | /api/produtos/{id} | Atualiza um produto |
| DELETE | /api/produtos/{id} | Remove um produto |

## Exemplo de payload

```json
{
  "nome": "Camiseta Básica Preta",
  "descricao": "Camiseta 100% algodão",
  "sku": "CAM-PRETA-M",
  "preco": 59.90,
  "quantidadeEstoque": 50
}
```

## Funcionalidades atuais

- Cadastro de produtos
- Consulta de produtos
- Atualização de produto
- Exclusão de produto
- Persistência em banco SQL Server
- Estrutura pronta para expansão com novas entidades e regras de negócio

## Próximos passos

- Implementar relacionamento com categoria
- Criar DTOs para evitar exposição direta da entidade
- Adicionar validações com FluentValidation
- Incluir paginação e filtros na listagem
- Adicionar autenticação e autorização
- Melhorar tratamento de erros e respostas da API

## Observações

Este projeto foi desenvolvimento e foi estruturado com foco em aprendizado prático de arquitetura .NET, boas práticas de camada, e integração com banco de dados relational.

---

Desenvolvido para estudo e evolução contínua da aplicação.
