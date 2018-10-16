
using LS.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LS.Infra.Data
{
    public sealed class LSDbContext : DbContext
    {
        public LSDbContext(DbContextOptions options): base(options) {
            Database.EnsureCreated();
        }


        public DbSet<User> User { get; set; }
    }
}
