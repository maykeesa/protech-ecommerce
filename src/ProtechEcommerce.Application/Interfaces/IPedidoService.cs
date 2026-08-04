using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Application.Interfaces;

public interface IPedidoService
{
    Task<PaginaResultado<Pedido>> BuscarAsync(PedidoFiltro filtro, int pagina, int tamanhoPagina, CancellationToken cancellationToken = default);
    Task<Pedido> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Pedido> CadastrarAsync(Guid compradorId, List<ItemPedidoInput> itens, CancellationToken cancellationToken = default);
    Task<Pedido> AtualizarAsync(Guid id, StatusPedido status, List<ItemPedidoInput> itens, CancellationToken cancellationToken = default);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken = default);
}
