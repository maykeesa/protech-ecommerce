using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public class IniciadoEstado : IEstadoPedido
{
    public StatusPedido Status => StatusPedido.INICIADO;
    public bool PermiteAlterarItens => true;

    public bool PodeTransicionarPara(StatusPedido novoStatus) => novoStatus switch
    {
        StatusPedido.INICIADO => true,
        StatusPedido.PROCESSADO => true,
        StatusPedido.CANCELADO => true,
        _ => false
    };
}
