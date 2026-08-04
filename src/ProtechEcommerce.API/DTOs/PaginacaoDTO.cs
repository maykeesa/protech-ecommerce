using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class PaginacaoDTO
{
    [SwaggerSchema("Numero da pagina, comecando em 1")]
    public int? Pagina { get; set; }

    [SwaggerSchema("Quantidade de itens por pagina")]
    public int? TamanhoPagina { get; set; }
}
