# Protech Ecommerce - 🛒

API RESTful em **.NET 10** para gerenciamento de pedidos de um e-commerce, construída com **Clean Architecture**, **Minimal APIs**, **Entity Framework Core** e **SQL Server**.

Permite cadastrar, listar (com filtro dinâmico e paginação), alterar e excluir pedidos. O fluxo de status do pedido (`INICIADO` → `PROCESSADO` → `ENVIADO` / `CANCELADO`) é controlado por um **State Pattern**, garantindo que só transições válidas sejam aceitas.

## 📦 Collections

Na pasta [`collections/`](./collections) tem exemplos prontos de todas as requisições da API, já preenchidos com dados de exemplo (os mesmos que a aplicação semeia automaticamente no banco ao subir):

- [`collections/bruno`](./collections/bruno)
- [`collections/postman`](./collections/postman)

## 🚀 Como rodar?

### Opção 1 — Docker (recomendado)

Só precisa ter o [Docker](https://www.docker.com/) instalado. Na raiz do projeto:

```bash
docker compose up --build
```

A API fica disponível em `http://localhost:5098`, com o Swagger em `http://localhost:5098/swagger`.

Para derrubar:

```bash
docker compose down
```

### Opção 2 — Local (sem Docker)

Pré-requisitos: [.NET SDK 10+](https://dotnet.microsoft.com/download) e um SQL Server acessível.

1. Configure a connection string em `src/ProtechEcommerce.API/appsettings.json` (chave `ConnectionStrings:DefaultConnection`)
2. Restaure e rode a API:

```bash
cd src/ProtechEcommerce.API
dotnet run
```