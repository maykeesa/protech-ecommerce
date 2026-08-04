using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Application.Interfaces;

public interface IPedidoService
{
    Task<List<Pedido>> BuscarAsync();
    Task<Pedido> BuscarPorIdAsync(Guid id);
    Task<Pedido> CadastrarAsync(Guid compradorId, List<ItemPedidoInput> itens);
    Task<Pedido> AtualizarAsync(Guid id, StatusPedido status, List<ItemPedidoInput> itens);
    Task ExcluirAsync(Guid id);
}
