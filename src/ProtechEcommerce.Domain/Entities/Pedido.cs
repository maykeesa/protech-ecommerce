using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.Entities;

public class Pedido : EntidadeBase
{
    public Guid CompradorId { get; set; }
    public Comprador Comprador { get; set; } = null!;
    public StatusPedido Status { get; set; }
    public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}
