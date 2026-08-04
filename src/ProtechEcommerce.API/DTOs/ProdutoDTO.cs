using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class ProdutoDTO
{
    public static class Request
    {
        public class Filtro
        {
            [SwaggerSchema("Identificador do produto")]
            public Guid? Id { get; set; }

            [SwaggerSchema("Nome do produto")]
            public string? Nome { get; set; }

            [SwaggerSchema("Preco minimo")]
            public decimal? PrecoMinimo { get; set; }

            [SwaggerSchema("Preco maximo")]
            public decimal? PrecoMaximo { get; set; }

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
