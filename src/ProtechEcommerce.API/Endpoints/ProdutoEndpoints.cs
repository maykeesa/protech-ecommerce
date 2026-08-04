using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.Application.Interfaces;

namespace ProtechEcommerce.API.Endpoints;

public static class ProdutoEndpoints
{
    public static IEndpointRouteBuilder MapProdutoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/produtos").WithTags("Produto");

        group.MapGet("/", async (IProdutoService service, IMapper mapper) =>
        {
            var produtos = await service.BuscarAsync();
            return Results.Ok(mapper.Map<List<ProdutoDTO.Response.Produto>>(produtos));
        })
        .WithSummary("Listar todos os produtos")
        .Produces<List<ProdutoDTO.Response.Produto>>();

        group.MapGet("/{id:guid}", async (Guid id, IProdutoService service, IMapper mapper) =>
        {
            var produto = await service.BuscarPorIdAsync(id);
            return Results.Ok(mapper.Map<ProdutoDTO.Response.Produto>(produto));
        })
        .WithSummary("Buscar produto por id")
        .Produces<ProdutoDTO.Response.Produto>()
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
