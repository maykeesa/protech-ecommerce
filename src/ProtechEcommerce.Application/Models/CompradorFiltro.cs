namespace ProtechEcommerce.Application.Models;

public record CompradorFiltro(
    Guid? Id = null,
    string? Nome = null,
    string? CpfCnpj = null,
    DateTime? DataCriacaoInicial = null,
    DateTime? DataCriacaoFinal = null,
    DateTime? DataAtualizacaoInicial = null,
    DateTime? DataAtualizacaoFinal = null);
