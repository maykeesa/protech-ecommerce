using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public class EnviadoEstado : IEstadoPedido
{
    public StatusPedido Status => StatusPedido.ENVIADO;
    public bool PermiteAlterarItens => false;

    public bool PodeTransicionarPara(StatusPedido novoStatus) => novoStatus == StatusPedido.ENVIADO;
}
