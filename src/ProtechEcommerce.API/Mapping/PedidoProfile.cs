using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.Application.Models;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.API.Mapping;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<ItemPedidoDTO.Request.Item, ItemPedidoInput>();
        CreateMap<ItemPedido, ItemPedidoDTO.Response.Item>();
        CreateMap<Pedido, PedidoDTO.Response.Pedido>();
        CreateMap<PedidoDTO.Request.Filtro, PedidoFiltro>();
    }
}
