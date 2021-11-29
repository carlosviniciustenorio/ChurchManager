using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChurchManager.Infrastructure.Persistencia
{
    public class IdDbContext : IdentityDbContext
    {
        public IdDbContext(DbContextOptions<IdDbContext> options) : base(options)
        { }
    }
}
