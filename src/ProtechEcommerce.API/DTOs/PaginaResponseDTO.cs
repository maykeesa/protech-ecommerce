using ProtechEcommerce.API.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class PaginaResponseDTO<T>
{
    [SwaggerSchema("Dados da pagina atual")]
    public List<T> Dados { get; set; } = [];

    [SwaggerSchema("Numero da pagina atual")]
    [SwaggerExample(1)]
    public int PaginaAtual { get; set; }

    [SwaggerSchema("Quantidade de itens por pagina")]
    [SwaggerExample(15)]
    public int TamanhoPagina { get; set; }

    [SwaggerSchema("Quantidade total de itens")]
    [SwaggerExample(3)]
    public int TotalItens { get; set; }

    [SwaggerSchema("Quantidade total de paginas")]
    [SwaggerExample(1)]
    public int TotalPaginas { get; set; }
}
