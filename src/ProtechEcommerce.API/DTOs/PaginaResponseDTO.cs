using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class PaginaResponseDTO<T>
{
    [SwaggerSchema("Itens da pagina atual")]
    public List<T> Itens { get; set; } = [];

    [SwaggerSchema("Numero da pagina atual")]
    public int PaginaAtual { get; set; }

    [SwaggerSchema("Quantidade de itens por pagina")]
    public int TamanhoPagina { get; set; }

    [SwaggerSchema("Quantidade total de itens")]
    public int TotalItens { get; set; }

    [SwaggerSchema("Quantidade total de paginas")]
    public int TotalPaginas { get; set; }
}
