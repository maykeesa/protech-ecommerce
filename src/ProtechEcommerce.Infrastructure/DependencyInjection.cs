using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Infrastructure.Repositories;

namespace ProtechEcommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<ICompradorRepository, CompradorRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        return services;
    }
}
