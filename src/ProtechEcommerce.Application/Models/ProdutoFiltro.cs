namespace ProtechEcommerce.Application.Models;

public record ProdutoFiltro(
    Guid? Id = null,
    string? Nome = null,
    decimal? PrecoMinimo = null,
    decimal? PrecoMaximo = null,
    DateTime? DataCriacaoInicial = null,
    DateTime? DataCriacaoFinal = null,
    DateTime? DataAtualizacaoInicial = null,
    DateTime? DataAtualizacaoFinal = null);
