using System.ComponentModel.DataAnnotations;
using ProtechEcommerce.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class PedidoDTO
{
    public static class Request
    {
        public class Cadastrar
        {
            [Required(ErrorMessage = "O comprador e obrigatorio")]
            [SwaggerSchema("Identificador do comprador")]
            public Guid CompradorId { get; set; }

            [Required(ErrorMessage = "O pedido deve ter ao menos um item")]
            [MinLength(1, ErrorMessage = "O pedido deve ter ao menos um item")]
            [SwaggerSchema("Itens do pedido")]
            public List<ItemPedidoDTO.Request.Item> Itens { get; set; } = [];
        }

        public class Atualizar
        {
            [Required(ErrorMessage = "O status e obrigatorio")]
            [SwaggerSchema("Status do pedido")]
            public StatusPedido Status { get; set; }

            [Required(ErrorMessage = "O pedido deve ter ao menos um item")]
            [MinLength(1, ErrorMessage = "O pedido deve ter ao menos um item")]
            [SwaggerSchema("Itens do pedido")]
            public List<ItemPedidoDTO.Request.Item> Itens { get; set; } = [];
        }

        public class Filtro
        {
            [SwaggerSchema("Identificador do pedido")]
            public Guid? Id { get; set; }

            [SwaggerSchema("Identificador do comprador")]
            public Guid? CompradorId { get; set; }

            [SwaggerSchema("Status do pedido")]
            public StatusPedido? Status { get; set; }

            [SwaggerSchema("Data de criacao inicial")]
            public DateTime? DataCriacaoInicial { get; set; }

            [SwaggerSchema("Data de criacao final")]
            public DateTime? DataCriacaoFinal { get; set; }

            [SwaggerSchema("Data de atualizacao inicial")]
            public DateTime? DataAtualizacaoInicial { get; set; }

            [SwaggerSchema("Data de atualizacao final")]
            public DateTime? DataAtualizacaoFinal { get; set; }
        }
    }

    public static class Response
    {
        public class Pedido
        {
            [SwaggerSchema("Identificador do pedido")]
            public Guid Id { get; set; }

            [SwaggerSchema("Identificador do comprador")]
            public Guid CompradorId { get; set; }

            [SwaggerSchema("Status do pedido")]
            public StatusPedido Status { get; set; }

            [SwaggerSchema("Itens do pedido")]
            public List<ItemPedidoDTO.Response.Item> Itens { get; set; } = [];

            [SwaggerSchema("Data de criacao do pedido")]
            public DateTime DataCriacao { get; set; }

            [SwaggerSchema("Data da ultima atualizacao do pedido")]
            public DateTime? DataAtualizacao { get; set; }
        }
    }
}
