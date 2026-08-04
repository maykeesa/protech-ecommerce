using Ardalis.Specification;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Application.Specifications;

public class CompradorSomenteLeituraSpecification : Specification<Comprador>
{
    public CompradorSomenteLeituraSpecification()
    {
        Query.AsNoTracking();
    }

    public CompradorSomenteLeituraSpecification(Guid id) : this()
    {
        Query.Where(c => c.Id == id);
    }
}
