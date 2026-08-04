using AutoMapper;
using ProtechEcommerce.API.DTOs;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.API.Mapping;

public class CompradorProfile : Profile
{
    public CompradorProfile()
    {
        CreateMap<Comprador, CompradorDTO.Response.Comprador>();
    }
}
