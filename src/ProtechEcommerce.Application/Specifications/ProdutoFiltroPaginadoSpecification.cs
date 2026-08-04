using Ardalis.Specification;
using ProtechEcommerce.Application.Models;

namespace ProtechEcommerce.Application.Specifications;

public class ProdutoFiltroPaginadoSpecification : ProdutoFiltroSpecification
{
    public ProdutoFiltroPaginadoSpecification(ProdutoFiltro filtro, int pagina, int tamanhoPagina) : base(filtro)
    {
        Query.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina);
    }
}
