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
    public async Task<List<Pedido>> BuscarAsync()
    {
        return await pedidoRepository.ListAsync(new PedidoComItensSpecification());
    }

    public async Task<Pedido> BuscarPorIdAsync(Guid id)
    {
        return await pedidoRepository.FirstOrDefaultAsync(new PedidoComItensSpecification(id))
            ?? throw new EntityNotFoundException("Pedido nao encontrado");
    }

    public async Task<Pedido> CadastrarAsync(Guid compradorId, List<ItemPedidoInput> itens)
    {
        if (itens.Count == 0)
            throw new ServiceException("O pedido deve ter ao menos um item");

        var comprador = await compradorRepository.GetByIdAsync(compradorId)
            ?? throw new EntityNotFoundException("Comprador nao encontrado");

        var pedido = new Pedido
        {
            CompradorId = comprador.Id,
            Status = StatusPedido.Iniciado,
            Itens = await pedidoServiceHelper.MontarItensAsync(itens)
        };

        return await pedidoRepository.AddAsync(pedido);
    }

    public async Task<Pedido> AtualizarAsync(Guid id, StatusPedido status, List<ItemPedidoInput> itens)
    {
        var pedido = await pedidoRepository.FirstOrDefaultAsync(new PedidoComItensSpecification(id))
            ?? throw new EntityNotFoundException("Pedido nao encontrado");

        var estadoAtual = EstadoPedidoFactory.ObterEstado(pedido.Status);

        if (!estadoAtual.PodeTransicionarPara(status))
            throw new ServiceException($"Nao e possivel transicionar o pedido de {pedido.Status} para {status}");

        if (estadoAtual.PermiteAlterarItens)
        {
            if (itens.Count == 0)
                throw new ServiceException("O pedido deve ter ao menos um item");

            pedido.Itens.Clear();
            foreach (var item in await pedidoServiceHelper.MontarItensAsync(itens))
            {
                pedido.Itens.Add(item);
            }
        }

        pedido.Status = status;

        await pedidoRepository.SaveChangesAsync();
        return pedido;
    }

    public async Task ExcluirAsync(Guid id)
    {
        var pedido = await pedidoRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Pedido nao encontrado");

        await pedidoRepository.DeleteAsync(pedido);
    }
}
