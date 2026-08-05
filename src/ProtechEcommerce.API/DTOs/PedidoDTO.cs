using System.ComponentModel.DataAnnotations;
using ProtechEcommerce.API.Swagger;
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
            [SwaggerExample("c16be931-4517-437e-9de6-0f661b2834da")]
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
            [SwaggerExample("PROCESSADO")]
            public StatusPedido Status { get; set; }

            [Required(ErrorMessage = "O pedido deve ter ao menos um item")]
            [MinLength(1, ErrorMessage = "O pedido deve ter ao menos um item")]
            [SwaggerSchema("Itens do pedido")]
            public List<ItemPedidoDTO.Request.Item> Itens { get; set; } = [];
        }

        public class Filtro
        {
            [SwaggerSchema("Identificador do pedido")]
            [SwaggerExample("59987996-d94f-42dd-b925-48c87b83da67")]
            public Guid? Id { get; set; }

            [SwaggerSchema("Identificador do comprador")]
            [SwaggerExample("c16be931-4517-437e-9de6-0f661b2834da")]
            public Guid? CompradorId { get; set; }

            [SwaggerSchema("Status do pedido")]
            [SwaggerExample("INICIADO")]
            public StatusPedido? Status { get; set; }

            [SwaggerSchema("Data de criacao inicial")]
            [SwaggerExample("2026-08-01")]
            public DateTime? DataCriacaoInicial { get; set; }

            [SwaggerSchema("Data de criacao final")]
            [SwaggerExample("2026-08-31")]
            public DateTime? DataCriacaoFinal { get; set; }

            [SwaggerSchema("Data de atualizacao inicial")]
            [SwaggerExample("2026-08-01")]
            public DateTime? DataAtualizacaoInicial { get; set; }

            [SwaggerSchema("Data de atualizacao final")]
            [SwaggerExample("2026-08-31")]
            public DateTime? DataAtualizacaoFinal { get; set; }
        }
    }

    public static class Response
    {
        public class Pedido
        {
            [SwaggerSchema("Identificador do pedido")]
            [SwaggerExample("59987996-d94f-42dd-b925-48c87b83da67")]
            public Guid Id { get; set; }

            [SwaggerSchema("Identificador do comprador")]
            [SwaggerExample("c16be931-4517-437e-9de6-0f661b2834da")]
            public Guid CompradorId { get; set; }

            [SwaggerSchema("Status do pedido")]
            [SwaggerExample("INICIADO")]
            public StatusPedido Status { get; set; }

            [SwaggerSchema("Itens do pedido")]
            public List<ItemPedidoDTO.Response.Item> Itens { get; set; } = [];

            [SwaggerSchema("Data de criacao do pedido")]
            [SwaggerExample("2026-08-05T10:25:55.410Z")]
            public DateTime DataCriacao { get; set; }

            [SwaggerSchema("Data da ultima atualizacao do pedido")]
            [SwaggerExample("2026-08-05T10:25:55.410Z")]
            public DateTime? DataAtualizacao { get; set; }
        }
    }
}
