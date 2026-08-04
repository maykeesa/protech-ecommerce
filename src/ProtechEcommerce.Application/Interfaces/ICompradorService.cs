using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Interfaces;

public interface ICompradorService
{
    Task<PaginaResultado<Comprador>> BuscarAsync(CompradorFiltro filtro, int pagina, int tamanhoPagina, CancellationToken cancellationToken = default);
    Task<Comprador> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken = default);
}
