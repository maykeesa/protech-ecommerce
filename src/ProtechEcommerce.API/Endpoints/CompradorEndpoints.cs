using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.Application.Interfaces;

namespace ProtechEcommerce.API.Endpoints;

public static class CompradorEndpoints
{
    public static IEndpointRouteBuilder MapCompradorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/compradores").WithTags("Comprador");

        group.MapGet("/", async (ICompradorService service, IMapper mapper) =>
        {
            var compradores = await service.BuscarAsync();
            return Results.Ok(mapper.Map<List<CompradorDTO.Response.Comprador>>(compradores));
        })
        .WithSummary("Listar todos os compradores")
        .Produces<List<CompradorDTO.Response.Comprador>>();

        group.MapGet("/{id:guid}", async (Guid id, ICompradorService service, IMapper mapper) =>
        {
            var comprador = await service.BuscarPorIdAsync(id);
            return Results.Ok(mapper.Map<CompradorDTO.Response.Comprador>(comprador));
        })
        .WithSummary("Buscar comprador por id")
        .Produces<CompradorDTO.Response.Comprador>()
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
