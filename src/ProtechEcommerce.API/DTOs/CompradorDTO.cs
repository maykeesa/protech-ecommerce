using ProtechEcommerce.API.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class CompradorDTO
{
    public static class Request
    {
        public class Filtro
        {
            [SwaggerSchema("Identificador do comprador")]
            [SwaggerExample("c16be931-4517-437e-9de6-0f661b2834da")]
            public Guid? Id { get; set; }

            [SwaggerSchema("Nome do comprador")]
            [SwaggerExample("Maria Oliveira Silva")]
            public string? Nome { get; set; }

            [SwaggerSchema("CPF ou CNPJ do comprador")]
            [SwaggerExample("52998224725")]
            public string? CpfCnpj { get; set; }

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
        public class Comprador
        {
            [SwaggerSchema("Identificador do comprador")]
            [SwaggerExample("c16be931-4517-437e-9de6-0f661b2834da")]
            public Guid Id { get; set; }

            [SwaggerSchema("Nome do comprador")]
            [SwaggerExample("Maria Oliveira Silva")]
            public string Nome { get; set; } = string.Empty;

            [SwaggerSchema("CPF ou CNPJ do comprador")]
            [SwaggerExample("52998224725")]
            public string CpfCnpj { get; set; } = string.Empty;

            [SwaggerSchema("Data de criacao do comprador")]
            [SwaggerExample("2026-08-05T10:18:51.997Z")]
            public DateTime DataCriacao { get; set; }

            [SwaggerSchema("Data da ultima atualizacao do comprador")]
            [SwaggerExample("2026-08-05T10:18:51.997Z")]
            public DateTime? DataAtualizacao { get; set; }
        }
    }
}
