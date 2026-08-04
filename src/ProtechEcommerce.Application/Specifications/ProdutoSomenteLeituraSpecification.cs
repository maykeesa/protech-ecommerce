using Ardalis.Specification;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Specifications;

public class ProdutoSomenteLeituraSpecification : Specification<Produto>
{
    public ProdutoSomenteLeituraSpecification()
    {
        Query.AsNoTracking();
    }

    public ProdutoSomenteLeituraSpecification(Guid id) : this()
    {
        Query.Where(p => p.Id == id);
    }
}
