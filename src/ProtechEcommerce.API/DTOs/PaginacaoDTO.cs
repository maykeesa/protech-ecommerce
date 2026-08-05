using ProtechEcommerce.API.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class PaginacaoDTO
{
    [SwaggerSchema("Numero da pagina, comecando em 1")]
    [SwaggerExample(1)]
    public int? Pagina { get; set; }

    [SwaggerSchema("Quantidade de itens por pagina")]
    [SwaggerExample(15)]
    public int? TamanhoPagina { get; set; }
}
