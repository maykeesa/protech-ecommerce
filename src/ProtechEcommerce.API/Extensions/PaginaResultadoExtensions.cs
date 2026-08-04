using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.Application.Models;

namespace ProtechEcommerce.API.Extensions;

public static class PaginaResultadoExtensions
{
    public static PaginaResponseDTO<TDto> ParaResponse<TEntity, TDto>(this PaginaResultado<TEntity> resultado, IMapper mapper)
    {
        return new PaginaResponseDTO<TDto>
        {
            Itens = mapper.Map<List<TDto>>(resultado.Itens),
            PaginaAtual = resultado.PaginaAtual,
            TamanhoPagina = resultado.TamanhoPagina,
            TotalItens = resultado.TotalItens,
            TotalPaginas = resultado.TotalPaginas
        };
    }
}
