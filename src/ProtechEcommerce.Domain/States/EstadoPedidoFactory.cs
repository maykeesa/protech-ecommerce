using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Domain.States;

public static class EstadoPedidoFactory
{
    public static IEstadoPedido ObterEstado(StatusPedido status) => status switch
    {
        StatusPedido.Iniciado => new IniciadoEstado(),
        StatusPedido.Processado => new ProcessadoEstado(),
        StatusPedido.Enviado => new EnviadoEstado(),
        StatusPedido.Cancelado => new CanceladoEstado(),
        _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Status de pedido desconhecido")
    };
}
