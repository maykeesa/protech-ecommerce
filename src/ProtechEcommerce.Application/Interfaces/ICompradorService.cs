using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Interfaces;

public interface ICompradorService
{
    Task<List<Comprador>> BuscarAsync();
    Task<Comprador> BuscarPorIdAsync(Guid id);
}
