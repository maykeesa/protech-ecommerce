using Ardalis.Specification;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Specifications;

public class PedidoComItensSpecification : Specification<Pedido>
{
    public PedidoComItensSpecification()
    {
        Query
            .Include(p => p.Comprador)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto);
    }

    public PedidoComItensSpecification(Guid id) : this()
    {
        Query.Where(p => p.Id == id);
    }
}
