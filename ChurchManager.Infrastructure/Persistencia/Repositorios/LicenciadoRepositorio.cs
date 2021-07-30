using ChurchManager.Application.Interfaces.Repositorios;
using ChurchManager.Application.Licenciados;

namespace ChurchManager.Infrastructure.Persistencia.Repositorios
{
    public class LicenciadoRepositorio : RepositorioLicenciado<Licenciado>, ILicenciadoRepositorio
    {
        public LicenciadoRepositorio(LicenciadosDBContext context) : base(context)
        { }
    }
}
