using ProtechEcommerce.Application.Helpers;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Application.Specifications;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Enums;
using ProtechEcommerce.Domain.Exceptions;
using ProtechEcommerce.Domain.States;

namespace ProtechEcommerce.Application.Services;

internal class PedidoService(
    IPedidoRepository pedidoRepository,
    ICompradorRepository compradorRepository,
    PedidoServiceHelper pedidoServiceHelper) : IPedidoService
{
    public async Task<PaginaResultado<Pedido>> BuscarAsync(PedidoFiltro filtro, int pagina, int tamanhoPagina, CancellationToken cancellationToken = default)
    {
        var totalItens = await pedidoRepository.CountAsync(new PedidoFiltroSpecification(filtro), cancellationToken);
        var itens = await pedidoRepository.ListAsync(new PedidoFiltroPaginadoSpecification(filtro, pagina, tamanhoPagina), cancellationToken);

        return new PaginaResultado<Pedido>(itens, pagina, tamanhoPagina, totalItens);
    }

    public async Task<Pedido> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await pedidoRepository.FirstOrDefaultAsync(new PedidoComItensSomenteLeituraSpecification(id), cancellationToken)
            ?? throw new EntityNotFoundException("Pedido nao encontrado");
    }

    public async Task<Pedido> CadastrarAsync(Guid compradorId, List<ItemPedidoInput> itens, CancellationToken cancellationToken = default)
    {
        if (itens.Count == 0)
            throw new ServiceException("O pedido deve ter ao menos um item");

        var comprador = await compradorRepository.GetByIdAsync(compradorId, cancellationToken)
            ?? throw new EntityNotFoundException("Comprador nao encontrado");

        var pedido = new Pedido
        {
            CompradorId = comprador.Id,
            Status = StatusPedido.INICIADO,
            Itens = await pedidoServiceHelper.MontarItensAsync(itens, cancellationToken)
        };

        return await pedidoRepository.AddAsync(pedido, cancellationToken);
    }

    public async Task<Pedido> AtualizarAsync(Guid id, StatusPedido status, List<ItemPedidoInput> itens, CancellationToken cancellationToken = default)
    {
        var pedido = await pedidoRepository.FirstOrDefaultAsync(new PedidoComItensSpecification(id), cancellationToken)
            ?? throw new EntityNotFoundException("Pedido nao encontrado");

        var estadoAtual = EstadoPedidoFactory.ObterEstado(pedido.Status);

        if (!estadoAtual.PodeTransicionarPara(status))
            throw new ServiceException($"Nao e possivel transicionar o pedido de {pedido.Status} para {status}");

        if (estadoAtual.PermiteAlterarItens)
        {
            if (itens.Count == 0)
                throw new ServiceException("O pedido deve ter ao menos um item");

            pedido.Itens.Clear();
            foreach (var item in await pedidoServiceHelper.MontarItensAsync(itens, cancellationToken))
            {
                pedido.Itens.Add(item);
            }
        }

        pedido.Status = status;

        await pedidoRepository.SaveChangesAsync(cancellationToken);
        return pedido;
    }

    public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException("Pedido nao encontrado");

        await pedidoRepository.DeleteAsync(pedido, cancellationToken);
    }
}
