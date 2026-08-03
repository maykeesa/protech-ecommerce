namespace ProtechEcommerce.Domain.Entities;

public class Comprador : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string CpfCnpj { get; set; } = string.Empty;
}
