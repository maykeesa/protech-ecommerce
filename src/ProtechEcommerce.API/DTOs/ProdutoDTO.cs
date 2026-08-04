using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class ProdutoDTO
{
    public static class Response
    {
        public class Produto
        {
            [SwaggerSchema("Identificador do produto")]
            public Guid Id { get; set; }

            [SwaggerSchema("Nome do produto")]
            public string Nome { get; set; } = string.Empty;

            [SwaggerSchema("Preco do produto")]
            public decimal Preco { get; set; }

            [SwaggerSchema("Data de criacao do produto")]
            public DateTime DataCriacao { get; set; }

            [SwaggerSchema("Data da ultima atualizacao do produto")]
            public DateTime? DataAtualizacao { get; set; }
        }
    }
}
