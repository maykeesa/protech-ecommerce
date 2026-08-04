using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public class ProcessadoEstado : IEstadoPedido
{
    public StatusPedido Status => StatusPedido.Processado;
    public bool PermiteAlterarItens => false;

    public bool PodeTransicionarPara(StatusPedido novoStatus) => novoStatus switch
    {
        StatusPedido.Processado => true,
        StatusPedido.Enviado => true,
        StatusPedido.Cancelado => true,
        _ => false
    };
}
