using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Interfaces;

public interface IProdutoService
{
    Task<List<Produto>> BuscarAsync();
    Task<Produto> BuscarPorIdAsync(Guid id);
}
