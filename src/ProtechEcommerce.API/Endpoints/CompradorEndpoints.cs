using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.API.Extensions;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.API.Endpoints;

public static class CompradorEndpoints
{
    public static IEndpointRouteBuilder MapCompradorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/compradores").WithTags("Comprador");

        group.MapGet("/", async ([AsParameters] CompradorDTO.Request.Filtro filtroDto, [AsParameters] PaginacaoDTO paginacao, ICompradorService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var filtro = mapper.Map<CompradorFiltro>(filtroDto);
            var resultado = await service.BuscarAsync(filtro, paginacao.Pagina ?? 1, paginacao.TamanhoPagina ?? 15, cancellationToken);

            return Results.Ok(resultado.ParaResponse<Comprador, CompradorDTO.Response.Comprador>(mapper));
        })
        .WithSummary("Listar compradores com filtro e paginacao")
        .Produces<PaginaResponseDTO<CompradorDTO.Response.Comprador>>();

        group.MapGet("/{id:guid}", async (Guid id, ICompradorService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var comprador = await service.BuscarPorIdAsync(id, cancellationToken);
            return Results.Ok(mapper.Map<CompradorDTO.Response.Comprador>(comprador));
        })
        .WithSummary("Buscar comprador por id")
        .Produces<CompradorDTO.Response.Comprador>()
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
