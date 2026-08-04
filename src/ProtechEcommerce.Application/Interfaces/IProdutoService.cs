using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Interfaces;

public interface IProdutoService
{
    Task<PaginaResultado<Produto>> BuscarAsync(ProdutoFiltro filtro, int pagina, int tamanhoPagina, CancellationToken cancellationToken = default);
    Task<Produto> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken = default);
}
