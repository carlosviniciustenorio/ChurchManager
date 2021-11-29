using ChurchManager.Domain.Interfaces.Repositorios;
using ChurchManager.Domain.Licenciados;

namespace ChurchManager.Infrastructure.Persistencia.Repositorios
{
    public class LicenciadoRepositorio : RepositorioLicenciado<Licenciado>, ILicenciadoRepositorio
    {
        public LicenciadoRepositorio(LicenciadosDBContext context) : base(context)
        { }
    }
}
