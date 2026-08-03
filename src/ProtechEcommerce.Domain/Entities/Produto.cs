namespace ProtechEcommerce.Domain.Entities;

public class Produto : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
