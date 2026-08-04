using Microsoft.Extensions.DependencyInjection;
using ProtechEcommerce.Application.Helpers;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Services;

namespace ProtechEcommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPedidoService, PedidoService>();
        services.AddScoped<ICompradorService, CompradorService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<PedidoServiceHelper>();

        return services;
    }
}
