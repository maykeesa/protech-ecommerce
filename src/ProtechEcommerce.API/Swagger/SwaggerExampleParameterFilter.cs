using System.Reflection;
using System.Text.Json;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProtechEcommerce.API.Swagger;

public class SwaggerExampleParameterFilter : IParameterFilter
{
    public void Apply(IOpenApiParameter parameter, ParameterFilterContext context)
    {
        var atributo = context.PropertyInfo?.GetCustomAttribute<SwaggerExampleAttribute>()
            ?? context.ParameterInfo?.GetCustomAttribute<SwaggerExampleAttribute>();

        if (atributo is null)
            return;

        var exemplo = JsonSerializer.SerializeToNode(atributo.Valor);

        if (parameter.Schema is OpenApiSchema schema)
        {
            schema.Example = exemplo;
        }

        if (parameter is OpenApiParameter parametroConcreto)
        {
            parametroConcreto.Example = exemplo;
        }
    }
}
