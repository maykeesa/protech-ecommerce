using Ardalis.Specification;
using ProtechEcommerce.Application.Models;

namespace ProtechEcommerce.Application.Specifications;

public class PedidoFiltroPaginadoSpecification : PedidoFiltroSpecification
{
    public PedidoFiltroPaginadoSpecification(PedidoFiltro filtro, int pagina, int tamanhoPagina) : base(filtro)
    {
        Query.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina);
    }
}
