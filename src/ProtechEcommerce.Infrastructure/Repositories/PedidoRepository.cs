using Ardalis.Specification.EntityFrameworkCore;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Infrastructure.Repositories;

public class PedidoRepository(AppDbContext context) : RepositoryBase<Pedido>(context), IPedidoRepository;
