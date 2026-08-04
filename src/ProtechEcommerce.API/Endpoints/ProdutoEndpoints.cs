using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.API.Extensions;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.API.Endpoints;

public static class ProdutoEndpoints
{
    public static IEndpointRouteBuilder MapProdutoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/produtos").WithTags("Produto");

        group.MapGet("/", async ([AsParameters] ProdutoDTO.Request.Filtro filtroDto, [AsParameters] PaginacaoDTO paginacao, IProdutoService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var filtro = mapper.Map<ProdutoFiltro>(filtroDto);
            var resultado = await service.BuscarAsync(filtro, paginacao.Pagina ?? 1, paginacao.TamanhoPagina ?? 15, cancellationToken);

            return Results.Ok(resultado.ParaResponse<Produto, ProdutoDTO.Response.Produto>(mapper));
        })
        .WithSummary("Listar produtos com filtro e paginacao")
        .Produces<PaginaResponseDTO<ProdutoDTO.Response.Produto>>();

        group.MapGet("/{id:guid}", async (Guid id, IProdutoService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var produto = await service.BuscarPorIdAsync(id, cancellationToken);
            return Results.Ok(mapper.Map<ProdutoDTO.Response.Produto>(produto));
        })
        .WithSummary("Buscar produto por id")
        .Produces<ProdutoDTO.Response.Produto>()
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
