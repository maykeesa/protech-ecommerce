using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public class EnviadoEstado : IEstadoPedido
{
    public StatusPedido Status => StatusPedido.Enviado;
    public bool PermiteAlterarItens => false;

    public bool PodeTransicionarPara(StatusPedido novoStatus) => novoStatus == StatusPedido.Enviado;
}
