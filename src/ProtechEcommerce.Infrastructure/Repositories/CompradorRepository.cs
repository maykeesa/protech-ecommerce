using Ardalis.Specification.EntityFrameworkCore;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Infrastructure.Repositories;

public class CompradorRepository(AppDbContext context) : RepositoryBase<Comprador>(context), ICompradorRepository;
