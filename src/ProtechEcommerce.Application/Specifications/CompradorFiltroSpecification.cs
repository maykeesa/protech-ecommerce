using Ardalis.Specification;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Specifications;

public class CompradorFiltroSpecification : Specification<Comprador>
{
    public CompradorFiltroSpecification(CompradorFiltro filtro)
    {
        Query
            .AsNoTracking()
            .Where(c => c.Id == filtro.Id, filtro.Id.HasValue)
            .Where(c => c.Nome.Contains(filtro.Nome!), !string.IsNullOrWhiteSpace(filtro.Nome))
            .Where(c => c.CpfCnpj == filtro.CpfCnpj, !string.IsNullOrWhiteSpace(filtro.CpfCnpj))
            .Where(c => c.DataCriacao >= filtro.DataCriacaoInicial, filtro.DataCriacaoInicial.HasValue)
            .Where(c => c.DataCriacao <= filtro.DataCriacaoFinal, filtro.DataCriacaoFinal.HasValue)
            .Where(c => c.DataAtualizacao >= filtro.DataAtualizacaoInicial, filtro.DataAtualizacaoInicial.HasValue)
            .Where(c => c.DataAtualizacao <= filtro.DataAtualizacaoFinal, filtro.DataAtualizacaoFinal.HasValue);
    }
}
