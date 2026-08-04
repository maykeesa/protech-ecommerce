using Ardalis.Specification;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Specifications;

public class PedidoFiltroSpecification : Specification<Pedido>
{
    public PedidoFiltroSpecification(PedidoFiltro filtro)
    {
        Query
            .Include(p => p.Comprador)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .AsNoTracking()
            .Where(p => p.Id == filtro.Id, filtro.Id.HasValue)
            .Where(p => p.CompradorId == filtro.CompradorId, filtro.CompradorId.HasValue)
            .Where(p => p.Status == filtro.Status, filtro.Status.HasValue)
            .Where(p => p.DataCriacao >= filtro.DataCriacaoInicial, filtro.DataCriacaoInicial.HasValue)
            .Where(p => p.DataCriacao <= filtro.DataCriacaoFinal, filtro.DataCriacaoFinal.HasValue)
            .Where(p => p.DataAtualizacao >= filtro.DataAtualizacaoInicial, filtro.DataAtualizacaoInicial.HasValue)
            .Where(p => p.DataAtualizacao <= filtro.DataAtualizacaoFinal, filtro.DataAtualizacaoFinal.HasValue);
    }
}
