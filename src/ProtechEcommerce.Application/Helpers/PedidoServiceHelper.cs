using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Application.Specifications;
using ProtechEcommerce.Domain.Entities;
using ProtechEcommerce.Domain.Exceptions;

namespace ProtechEcommerce.Application.Helpers;

internal class PedidoServiceHelper(IProdutoRepository produtoRepository)
{
    public async Task<List<ItemPedido>> MontarItensAsync(List<ItemPedidoInput> itens, CancellationToken cancellationToken = default)
    {
        var itensPedido = new List<ItemPedido>();

        foreach (var item in itens)
        {
            var produto = await produtoRepository.FirstOrDefaultAsync(new ProdutoSomenteLeituraSpecification(item.ProdutoId), cancellationToken)
                ?? throw new EntityNotFoundException($"Produto {item.ProdutoId} nao encontrado");

            itensPedido.Add(new ItemPedido
            {
                ProdutoId = produto.Id,
                Quantidade = item.Quantidade
            });
        }

        return itensPedido;
    }
}
