using ProtechEcommerce.Domain.Enums;

namespace ProtechEcommerce.Application.Models;

public record PedidoFiltro(
    Guid? Id = null,
    Guid? CompradorId = null,
    StatusPedido? Status = null,
    DateTime? DataCriacaoInicial = null,
    DateTime? DataCriacaoFinal = null,
    DateTime? DataAtualizacaoInicial = null,
    DateTime? DataAtualizacaoFinal = null);
