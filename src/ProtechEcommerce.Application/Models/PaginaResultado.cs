namespace ProtechEcommerce.Application.Models;

public class PaginaResultado<T>(List<T> dados, int paginaAtual, int tamanhoPagina, int totalItens)
{
    public List<T> Dados { get; } = dados;
    public int PaginaAtual { get; } = paginaAtual;
    public int TamanhoPagina { get; } = tamanhoPagina;
    public int TotalItens { get; } = totalItens;
    public int TotalPaginas { get; } = (int)Math.Ceiling(totalItens / (double)tamanhoPagina);
}
