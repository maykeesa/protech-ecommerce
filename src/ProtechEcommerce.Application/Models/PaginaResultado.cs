namespace ProtechEcommerce.Application.Models;

public class PaginaResultado<T>(List<T> itens, int paginaAtual, int tamanhoPagina, int totalItens)
{
    public List<T> Itens { get; } = itens;
    public int PaginaAtual { get; } = paginaAtual;
    public int TamanhoPagina { get; } = tamanhoPagina;
    public int TotalItens { get; } = totalItens;
    public int TotalPaginas { get; } = (int)Math.Ceiling(totalItens / (double)tamanhoPagina);
}
