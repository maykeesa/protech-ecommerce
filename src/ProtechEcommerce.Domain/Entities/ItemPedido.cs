namespace ProtechEcommerce.Domain.Entities;

public class ItemPedido : EntidadeBase
{
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public int Quantidade { get; set; }
}
