using ProtechEcommerce.API.Endpoints;
using ProtechEcommerce.API.ExceptionHandling;
using ProtechEcommerce.Application;
using ProtechEcommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.CustomSchemaIds(type =>
    {
        var nomes = new List<string>();
        for (var atual = type; atual is not null; atual = atual.DeclaringType)
        {
            nomes.Insert(0, atual.Name);
        }

        return string.Join(".", nomes);
    });
});
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
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.MapPedidoEndpoints();
app.MapCompradorEndpoints();
app.MapProdutoEndpoints();

app.Run();
