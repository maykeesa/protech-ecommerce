using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public class IniciadoEstado : IEstadoPedido
{
    public StatusPedido Status => StatusPedido.Iniciado;
    public bool PermiteAlterarItens => true;

    public bool PodeTransicionarPara(StatusPedido novoStatus) => novoStatus switch
    {
        StatusPedido.Iniciado => true,
        StatusPedido.Processado => true,
        StatusPedido.Cancelado => true,
        _ => false
    };
}
