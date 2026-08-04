using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;

namespace ProtechEcommerce.API.Endpoints;

public static class PedidoEndpoints
{
    public static IEndpointRouteBuilder MapPedidoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/pedidos").WithTags("Pedido");

        group.MapGet("/", async (IPedidoService service, IMapper mapper) =>
        {
            var pedidos = await service.BuscarAsync();
            return Results.Ok(mapper.Map<List<PedidoDTO.Response.Pedido>>(pedidos));
        })
        .WithSummary("Listar todos os pedidos")
        .Produces<List<PedidoDTO.Response.Pedido>>();

        group.MapGet("/{id:guid}", async (Guid id, IPedidoService service, IMapper mapper) =>
        {
            var pedido = await service.BuscarPorIdAsync(id);
            return Results.Ok(mapper.Map<PedidoDTO.Response.Pedido>(pedido));
        })
        .WithSummary("Buscar pedido por id")
        .Produces<PedidoDTO.Response.Pedido>()
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (PedidoDTO.Request.Cadastrar body, IPedidoService service, IMapper mapper) =>
        {
            var itens = mapper.Map<List<ItemPedidoInput>>(body.Itens);
            var pedido = await service.CadastrarAsync(body.CompradorId, itens);
            var response = mapper.Map<PedidoDTO.Response.Pedido>(pedido);
            return Results.Created($"/api/v1/pedidos/{response.Id}", response);
        })
        .WithSummary("Cadastrar um pedido")
        .Produces<PedidoDTO.Response.Pedido>(StatusCodes.Status201Created)
        .ProducesValidationProblem();

        group.MapPut("/{id:guid}", async (Guid id, PedidoDTO.Request.Atualizar body, IPedidoService service, IMapper mapper) =>
        {
            var itens = mapper.Map<List<ItemPedidoInput>>(body.Itens);
            var pedido = await service.AtualizarAsync(id, body.Status, itens);
            return Results.Ok(mapper.Map<PedidoDTO.Response.Pedido>(pedido));
        })
        .WithSummary("Atualizar um pedido")
        .Produces<PedidoDTO.Response.Pedido>()
        .Produces(StatusCodes.Status404NotFound)
        .ProducesValidationProblem();

        group.MapDelete("/{id:guid}", async (Guid id, IPedidoService service) =>
        {
            await service.ExcluirAsync(id);
            return Results.NoContent();
        })
        .WithSummary("Excluir um pedido")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
