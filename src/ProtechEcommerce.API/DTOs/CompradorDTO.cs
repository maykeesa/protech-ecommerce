using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class CompradorDTO
{
    public static class Request
    {
        public class Filtro
        {
            [SwaggerSchema("Identificador do comprador")]
            public Guid? Id { get; set; }

            [SwaggerSchema("Nome do comprador")]
            public string? Nome { get; set; }

            [SwaggerSchema("CPF ou CNPJ do comprador")]
            public string? CpfCnpj { get; set; }

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
        public class Comprador
        {
            [SwaggerSchema("Identificador do comprador")]
            public Guid Id { get; set; }

            [SwaggerSchema("Nome do comprador")]
            public string Nome { get; set; } = string.Empty;

            [SwaggerSchema("CPF ou CNPJ do comprador")]
            public string CpfCnpj { get; set; } = string.Empty;

            [SwaggerSchema("Data de criacao do comprador")]
            public DateTime DataCriacao { get; set; }

            [SwaggerSchema("Data da ultima atualizacao do comprador")]
            public DateTime? DataAtualizacao { get; set; }
        }
    }
}
