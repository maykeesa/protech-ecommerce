using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Application.Specifications;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Exceptions;

namespace ProtechEcommerce.Application.Services;

internal class CompradorService(ICompradorRepository compradorRepository) : ICompradorService
{
    public async Task<PaginaResultado<Comprador>> BuscarAsync(CompradorFiltro filtro, int pagina, int tamanhoPagina, CancellationToken cancellationToken = default)
    {
        var totalItens = await compradorRepository.CountAsync(new CompradorFiltroSpecification(filtro), cancellationToken);
        var itens = await compradorRepository.ListAsync(new CompradorFiltroPaginadoSpecification(filtro, pagina, tamanhoPagina), cancellationToken);

        return new PaginaResultado<Comprador>(itens, pagina, tamanhoPagina, totalItens);
    }

    public async Task<Comprador> BuscarPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await compradorRepository.FirstOrDefaultAsync(new CompradorSomenteLeituraSpecification(id), cancellationToken)
            ?? throw new EntityNotFoundException("Comprador nao encontrado");
    }
}
