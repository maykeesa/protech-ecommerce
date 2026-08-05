using ProtechEcommerce.API.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class ProdutoDTO
{
    public static class Request
    {
        public class Filtro
        {
            [SwaggerSchema("Identificador do produto")]
            [SwaggerExample("3642775f-2b41-44a0-894e-8bf03c5d54e4")]
            public Guid? Id { get; set; }

            [SwaggerSchema("Nome do produto")]
            [SwaggerExample("Notebook Gamer 16GB")]
            public string? Nome { get; set; }

            [SwaggerSchema("Preco minimo")]
            [SwaggerExample(50.0)]
            public decimal? PrecoMinimo { get; set; }

            [SwaggerSchema("Preco maximo")]
            [SwaggerExample(5000.0)]
            public decimal? PrecoMaximo { get; set; }

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
        public class Produto
        {
            [SwaggerSchema("Identificador do produto")]
            [SwaggerExample("3642775f-2b41-44a0-894e-8bf03c5d54e4")]
            public Guid Id { get; set; }

            [SwaggerSchema("Nome do produto")]
            [SwaggerExample("Notebook Gamer 16GB")]
            public string Nome { get; set; } = string.Empty;

            [SwaggerSchema("Preco do produto")]
            [SwaggerExample(4999.90)]
            public decimal Preco { get; set; }

            [SwaggerSchema("Data de criacao do produto")]
            [SwaggerExample("2026-08-05T10:18:51.997Z")]
            public DateTime DataCriacao { get; set; }

            [SwaggerSchema("Data da ultima atualizacao do produto")]
            [SwaggerExample("2026-08-05T10:18:51.997Z")]
            public DateTime? DataAtualizacao { get; set; }
        }
    }
}
