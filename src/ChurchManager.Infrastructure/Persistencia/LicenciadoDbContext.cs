using ChurchManager.Domain.Licenciados;
using Microsoft.EntityFrameworkCore;

namespace ChurchManager.Infrastructure.Persistencia
{
    public class LicenciadosDBContext : DbContext
    {
        public DbSet<Licenciado> Licenciado { get; set; }
        public DbSet<InfoBD> InfoBD { get; set; }

        public LicenciadosDBContext(DbContextOptions<LicenciadosDBContext> options)
            : base(options)
        { }
    }
}
