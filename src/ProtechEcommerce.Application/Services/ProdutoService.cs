using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Exceptions;

namespace ProtechEcommerce.Application.Services;

internal class ProdutoService(IProdutoRepository produtoRepository) : IProdutoService
{
    public async Task<List<Produto>> BuscarAsync()
    {
        return await produtoRepository.ListAsync();
    }

    public async Task<Produto> BuscarPorIdAsync(Guid id)
    {
        return await produtoRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Produto nao encontrado");
    }
}
