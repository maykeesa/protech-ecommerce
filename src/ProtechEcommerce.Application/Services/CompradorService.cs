using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Exceptions;

namespace ProtechEcommerce.Application.Services;

internal class CompradorService(ICompradorRepository compradorRepository) : ICompradorService
{
    public async Task<List<Comprador>> BuscarAsync()
    {
        return await compradorRepository.ListAsync();
    }

    public async Task<Comprador> BuscarPorIdAsync(Guid id)
    {
        return await compradorRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Comprador nao encontrado");
    }
}
