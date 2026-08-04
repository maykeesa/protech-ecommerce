using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Application.Specifications;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Exceptions;

namespace ProtechEcommerce.Application.Services;

internal class ProdutoService(IProdutoRepository produtoRepository) : IProdutoService
{
    public async Task<PaginaResultado<Produto>> BuscarAsync(ProdutoFiltro filtro, int pagina, int tamanhoPagina, CancellationToken cancellationToken = default)
    {
        var totalItens = await produtoRepository.CountAsync(new ProdutoFiltroSpecification(filtro), cancellationToken);
        var itens = await produtoRepository.ListAsync(new ProdutoFiltroPaginadoSpecification(filtro, pagina, tamanhoPagina), cancellationToken);

        return new PaginaResultado<Produto>(itens, pagina, tamanhoPagina, totalItens);
    }

    public async Task<Produto> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await produtoRepository.FirstOrDefaultAsync(new ProdutoSomenteLeituraSpecification(id), cancellationToken)
            ?? throw new EntityNotFoundException("Produto nao encontrado");
    }
}
