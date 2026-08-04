using Ardalis.Specification.EntityFrameworkCore;
using ProtechEcommerce.Application.Interfaces;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Infrastructure.Repositories;

public class ProdutoRepository(AppDbContext context) : RepositoryBase<Produto>(context), IProdutoRepository;
