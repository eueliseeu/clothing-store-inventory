# EstoqueRoupas

Inventory management system for a clothing store, developed with .NET 10 using ASP.NET Core Web API, Entity Framework Core, and SQL Server.

This project was created to serve as a practical foundation for learning software architecture, layer organization, data persistence, and REST API development in C#.

[README.md in Portuguese 🇧🇷](../README.md)

## Tech stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Dependency Injection
- Swagger / OpenAPI

## Architecture

The application follows a simple layered architecture to keep the codebase organized and easier to evolve over time:

| Project | Responsibility |
| --- | --- |
| EstoqueRoupas.Domain | Domain entities and interfaces |
| EstoqueRoupas.Infrastructure | DbContext, configurations, migrations, and service implementations |
| EstoqueRoupas.API | HTTP endpoints and API exposure |

The domain layer is the core of the application and does not depend on the infrastructure or presentation layers.

## Current project structure

- Entity: Produto
- Service interface: IProdutoService
- Service implementation: ProdutoService
- Controller: ProdutosController
- Persistence: AppDbContext + Fluent API

## Requirements

Before running the project, make sure you have the following installed:

- .NET 10 SDK
- SQL Server locally or through Docker
- Git

## Database configuration

The application uses the connection string defined in `EstoqueRoupas.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1,1433;Database=EstoqueRoupasDb;User Id=sa;Password=SenhaForte@2026;TrustServerCertificate=True;Encrypt=False;"
  }
}
```

If you prefer, you can start SQL Server with Docker using the following command:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SenhaForte@2026" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

## How to run

### 1. Restore dependencies

```bash
dotnet restore
```

### 2. Apply the database migrations

```bash
dotnet ef database update \
  --project EstoqueRoupas.Infrastructure \
  --startup-project EstoqueRoupas.API
```

### 3. Start the API

```bash
dotnet run --project EstoqueRoupas.API
```

The API will be available at:

```text
https://localhost:5125/api/produtos
```

The OpenAPI/Swagger documentation is available at:

```text
https://localhost:<port>/openapi/v1.json
```

## Main endpoints

| Method | Route | Description |
| --- | --- | --- |
| GET | /api/produtos | Lists all products |
| GET | /api/produtos/{id} | Gets a product by id |
| POST | /api/produtos | Creates a new product |
| PUT | /api/produtos/{id} | Updates an existing product |
| DELETE | /api/produtos/{id} | Deletes a product |

## Example payload

```json
{
  "nome": "Camiseta Básica Preta",
  "descricao": "Camiseta 100% algodão",
  "sku": "CAM-PRETA-M",
  "preco": 59.90,
  "quantidadeEstoque": 50
}
```

## Current features

- Product registration
- Product listing
- Product update
- Product deletion
- SQL Server persistence
- Project structure ready for future growth and new business rules

## Planned next steps

- Add category relationship
- Create DTOs to avoid exposing entities directly
- Add validation with FluentValidation
- Add pagination and filtering
- Add authentication and authorization
- Improve error handling and API responses

## Notes

This project was developed with a focus on practical learning of .NET architecture, layer separation best practices, and integration with a relational database.

---

Developed for study and ongoing improvement of the application.
