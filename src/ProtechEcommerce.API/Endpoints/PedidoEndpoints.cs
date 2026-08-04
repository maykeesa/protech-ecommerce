using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.API.Extensions;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.API.Endpoints;

public static class PedidoEndpoints
{
    public static IEndpointRouteBuilder MapPedidoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/pedidos").WithTags("Pedido");

        group.MapGet("/", async ([AsParameters] PedidoDTO.Request.Filtro filtroDto, [AsParameters] PaginacaoDTO paginacao, IPedidoService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var filtro = mapper.Map<PedidoFiltro>(filtroDto);
            var resultado = await service.BuscarAsync(filtro, paginacao.Pagina ?? 1, paginacao.TamanhoPagina ?? 15, cancellationToken);

            return Results.Ok(resultado.ParaResponse<Pedido, PedidoDTO.Response.Pedido>(mapper));
        })
        .WithSummary("Listar pedidos com filtro e paginacao")
        .Produces<PaginaResponseDTO<PedidoDTO.Response.Pedido>>();

        group.MapGet("/{id:guid}", async (Guid id, IPedidoService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var pedido = await service.BuscarPorIdAsync(id, cancellationToken);
            return Results.Ok(mapper.Map<PedidoDTO.Response.Pedido>(pedido));
        })
        .WithSummary("Buscar pedido por id")
        .Produces<PedidoDTO.Response.Pedido>()
        .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (PedidoDTO.Request.Cadastrar body, IPedidoService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var itens = mapper.Map<List<ItemPedidoInput>>(body.Itens);
            var pedido = await service.CadastrarAsync(body.CompradorId, itens, cancellationToken);
            var response = mapper.Map<PedidoDTO.Response.Pedido>(pedido);
            return Results.Created($"/api/v1/pedidos/{response.Id}", response);
        })
        .WithSummary("Cadastrar um pedido")
        .Produces<PedidoDTO.Response.Pedido>(StatusCodes.Status201Created)
        .ProducesValidationProblem();

        group.MapPut("/{id:guid}", async (Guid id, PedidoDTO.Request.Atualizar body, IPedidoService service, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var itens = mapper.Map<List<ItemPedidoInput>>(body.Itens);
            var pedido = await service.AtualizarAsync(id, body.Status, itens, cancellationToken);
            return Results.Ok(mapper.Map<PedidoDTO.Response.Pedido>(pedido));
        })
        .WithSummary("Atualizar um pedido")
        .Produces<PedidoDTO.Response.Pedido>()
        .Produces(StatusCodes.Status404NotFound)
        .ProducesValidationProblem();

        group.MapDelete("/{id:guid}", async (Guid id, IPedidoService service, CancellationToken cancellationToken) =>
        {
            await service.ExcluirAsync(id, cancellationToken);
            return Results.NoContent();
        })
        .WithSummary("Excluir um pedido")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
