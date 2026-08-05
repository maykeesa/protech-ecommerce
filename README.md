# Protech Ecommerce - 🛒

API RESTful em **.NET 10** para gerenciamento de pedidos de um e-commerce, construída com **Clean Architecture**, **Minimal APIs**, **Entity Framework Core** e **SQL Server**.

Permite cadastrar, listar (com filtro dinâmico e paginação), alterar e excluir pedidos. O fluxo de status do pedido (`INICIADO` → `PROCESSADO` → `ENVIADO` / `CANCELADO`) é controlado por um **State Pattern**, garantindo que só transições válidas sejam aceitas.

## 📦 Collections

Na pasta [`collections/`](./collections) tem exemplos prontos de todas as requisições da API, já preenchidos com dados de exemplo (os mesmos que a aplicação semeia automaticamente no banco ao subir):

- [`collections/bruno`](./collections/bruno) — collection no formato [Bruno](https://www.usebruno.com/)
- [`collections/postman`](./collections/postman) — a mesma collection convertida pro formato [Postman](https://www.postman.com/) (`.postman_collection.json`, pronta pra importar via *File > Import*)

## 🚀 Como rodar?

### Opção 1 — Docker (recomendado)

Só precisa ter o [Docker](https://www.docker.com/) instalado. Na raiz do projeto:

```bash
docker compose up --build
```

Isso sobe o SQL Server, aguarda ele ficar saudável, sobe a API, e a própria aplicação aplica as migrations e popula o banco com dados de exemplo automaticamente no startup. Nenhum passo manual adicional é necessário.

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

A própria aplicação já aplica as migrations e popula os dados de exemplo no startup (mesmo comportamento do Docker). A API sobe em `http://localhost:5098` (perfil `http` do `launchSettings.json`).
