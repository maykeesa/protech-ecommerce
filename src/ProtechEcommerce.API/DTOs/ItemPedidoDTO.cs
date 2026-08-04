using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class ItemPedidoDTO
{
    public static class Request
    {
        public class Item
        {
            [Required(ErrorMessage = "O produto e obrigatorio")]
            [SwaggerSchema("Identificador do produto")]
            public Guid ProdutoId { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
            [SwaggerSchema("Quantidade do produto")]
            public int Quantidade { get; set; }
        }
    }

    public static class Response
    {
        public class Item
        {
            [SwaggerSchema("Identificador do produto")]
            public Guid ProdutoId { get; set; }

            [SwaggerSchema("Quantidade do produto")]
            public int Quantidade { get; set; }
        }
    }
}
