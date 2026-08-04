using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public class CanceladoEstado : IEstadoPedido
{
    public StatusPedido Status => StatusPedido.Cancelado;
    public bool PermiteAlterarItens => false;

    public bool PodeTransicionarPara(StatusPedido novoStatus) => novoStatus == StatusPedido.Cancelado;
}
