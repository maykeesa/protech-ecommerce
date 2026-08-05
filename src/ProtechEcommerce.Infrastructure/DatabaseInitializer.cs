using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Infrastructure;

public static class DatabaseInitializer
{
    public static async Task MigrarEPopularAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        if (!await context.Compradores.AnyAsync())
        {
            context.Compradores.AddRange(
                new Comprador { Nome = "Maria Oliveira Silva", CpfCnpj = "52998224725" },
                new Comprador { Nome = "Comercio Tech Ltda", CpfCnpj = "11444777000161" },
                new Comprador { Nome = "Joao Pedro Santos", CpfCnpj = "01234567890" }
            );
        }

        if (!await context.Produtos.AnyAsync())
        {
            context.Produtos.AddRange(
                new Produto { Nome = "Notebook Gamer 16GB", Preco = 4999.90m },
                new Produto { Nome = "Mouse sem fio", Preco = 89.90m },
                new Produto { Nome = "Teclado Mecanico RGB", Preco = 349.50m },
                new Produto { Nome = "Monitor 27 polegadas 144Hz", Preco = 1899.00m }
            );
        }

        await context.SaveChangesAsync();
    }
}
