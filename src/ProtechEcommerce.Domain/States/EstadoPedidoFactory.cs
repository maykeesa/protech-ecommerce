using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public static class EstadoPedidoFactory
{
    public static IEstadoPedido ObterEstado(StatusPedido status) => status switch
    {
        StatusPedido.INICIADO => new IniciadoEstado(),
        StatusPedido.PROCESSADO => new ProcessadoEstado(),
        StatusPedido.ENVIADO => new EnviadoEstado(),
        StatusPedido.CANCELADO => new CanceladoEstado(),
        _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Status de pedido desconhecido")
    };
}
