using Ardalis.Specification;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Specifications;

public class ProdutoFiltroSpecification : Specification<Produto>
{
    public ProdutoFiltroSpecification(ProdutoFiltro filtro)
    {
        Query
            .AsNoTracking()
            .Where(p => p.Id == filtro.Id, filtro.Id.HasValue)
            .Where(p => p.Nome.Contains(filtro.Nome!), !string.IsNullOrWhiteSpace(filtro.Nome))
            .Where(p => p.Preco >= filtro.PrecoMinimo, filtro.PrecoMinimo.HasValue)
            .Where(p => p.Preco <= filtro.PrecoMaximo, filtro.PrecoMaximo.HasValue)
            .Where(p => p.DataCriacao >= filtro.DataCriacaoInicial, filtro.DataCriacaoInicial.HasValue)
            .Where(p => p.DataCriacao <= filtro.DataCriacaoFinal, filtro.DataCriacaoFinal.HasValue)
            .Where(p => p.DataAtualizacao >= filtro.DataAtualizacaoInicial, filtro.DataAtualizacaoInicial.HasValue)
            .Where(p => p.DataAtualizacao <= filtro.DataAtualizacaoFinal, filtro.DataAtualizacaoFinal.HasValue);
    }
}
