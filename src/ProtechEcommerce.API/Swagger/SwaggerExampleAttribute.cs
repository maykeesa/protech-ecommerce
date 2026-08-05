namespace ProtechEcommerce.API.Swagger;

[AttributeUsage(AttributeTargets.Property)]
public class SwaggerExampleAttribute(object valor) : Attribute
{
    public object Valor { get; } = valor;
}
