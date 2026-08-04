using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerUI;
using ProtechEcommerce.API.Endpoints;
using ProtechEcommerce.API.ExceptionHandling;
using ProtechEcommerce.Application;
using ProtechEcommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.CustomSchemaIds(ObterNomeSchema);
});

static string ObterNomeSchema(Type type)
{
    var nomes = new List<string>();
    for (var atual = type; atual is not null; atual = atual.DeclaringType)
    {
        var nome = atual.Name;
        var indiceBacktick = nome.IndexOf('`');
        if (indiceBacktick > 0)
        {
            nome = nome[..indiceBacktick];
        }

        nomes.Insert(0, nome);
    }

    var nomeBase = string.Join(".", nomes);

    if (!type.IsGenericType)
        return nomeBase;

    var argumentos = type.GetGenericArguments().Select(ObterNomeSchema);
    return $"{nomeBase}Of{string.Join("And", argumentos)}";
}

builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);
builder.Services.AddValidation();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(DocExpansion.None);
        options.EnableFilter();
        options.EnableDeepLinking();
    });
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.MapPedidoEndpoints();
app.MapCompradorEndpoints();
app.MapProdutoEndpoints();

app.Run();
