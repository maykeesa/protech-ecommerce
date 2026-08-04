using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public class ProcessadoEstado : IEstadoPedido
{
    public StatusPedido Status => StatusPedido.PROCESSADO;
    public bool PermiteAlterarItens => false;

    public bool PodeTransicionarPara(StatusPedido novoStatus) => novoStatus switch
    {
        StatusPedido.PROCESSADO => true,
        StatusPedido.ENVIADO => true,
        StatusPedido.CANCELADO => true,
        _ => false
    };
}
