using Swashbuckle.AspNetCore.Annotations;

namespace ProtechEcommerce.API.DTOs;

public class CompradorDTO
{
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
