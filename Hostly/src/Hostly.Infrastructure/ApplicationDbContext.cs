using Hostly.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Hostly.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}
