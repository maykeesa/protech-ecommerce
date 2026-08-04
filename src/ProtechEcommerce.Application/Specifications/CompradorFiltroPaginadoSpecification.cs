using Ardalis.Specification;
using ProtechEcommerce.Application.Models;

namespace ProtechEcommerce.Application.Specifications;

public class CompradorFiltroPaginadoSpecification : CompradorFiltroSpecification
{
    public CompradorFiltroPaginadoSpecification(CompradorFiltro filtro, int pagina, int tamanhoPagina) : base(filtro)
    {
        Query.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina);
    }
}
