using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.API.Mapping;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ProdutoDTO.Response.Produto>();
        CreateMap<ProdutoDTO.Request.Filtro, ProdutoFiltro>();
    }
}
