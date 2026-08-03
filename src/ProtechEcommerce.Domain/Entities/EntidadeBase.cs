namespace ProtechEcommerce.Domain.Entities;

public abstract class EntidadeBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}
