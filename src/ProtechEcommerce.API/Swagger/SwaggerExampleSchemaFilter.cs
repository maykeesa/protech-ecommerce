using System.Reflection;
using System.Text.Json;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProtechEcommerce.API.Swagger;

public class SwaggerExampleSchemaFilter : ISchemaFilter
{
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties is null)
            return;

        foreach (var propriedade in context.Type.GetProperties())
        {
            var atributo = propriedade.GetCustomAttribute<SwaggerExampleAttribute>();
            if (atributo is null)
                continue;

            var nomePropriedade = schema.Properties.Keys.FirstOrDefault(chave =>
                string.Equals(chave, propriedade.Name, StringComparison.OrdinalIgnoreCase));

            // Propriedades cujo schema e uma referencia (ex: enum compartilhado como StatusPedido)
            // nao aceitam Example local - a referencia e somente leitura nesses casos.
            if (nomePropriedade is not null && schema.Properties[nomePropriedade] is OpenApiSchema propriedadeSchema)
            {
                propriedadeSchema.Example = JsonSerializer.SerializeToNode(atributo.Valor);
            }
        }
    }
}
