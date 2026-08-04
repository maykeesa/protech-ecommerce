using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public interface IEstadoPedido
{
    StatusPedido Status { get; }
    bool PermiteAlterarItens { get; }
    bool PodeTransicionarPara(StatusPedido novoStatus);
}
