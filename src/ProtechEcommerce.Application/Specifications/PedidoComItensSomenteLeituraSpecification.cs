using Ardalis.Specification;

namespace ProtechEcommerce.Application.Specifications;

public class PedidoComItensSomenteLeituraSpecification : PedidoComItensSpecification
{
    public PedidoComItensSomenteLeituraSpecification()
    {
        Query.AsNoTracking();
    }

    public PedidoComItensSomenteLeituraSpecification(Guid id) : base(id)
    {
        Query.AsNoTracking();
    }
}
