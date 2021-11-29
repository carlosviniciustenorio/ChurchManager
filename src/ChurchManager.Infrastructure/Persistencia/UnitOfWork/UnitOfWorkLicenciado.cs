using ChurchManager.Infrastructure.Persistencia.Repositorios;

namespace ChurchManager.Infrastructure.Persistencia.UnitOfWork
{
    public class UnitOfWorkLicenciado : IUnitOfWorkLicenciado
    {
        private LicenciadosDBContext _contextLicenciado;
        Repositorios.LicenciadoRepositorio licenciadoRepositorio;

        public UnitOfWorkLicenciado(LicenciadosDBContext context)
        {
            _contextLicenciado = context;
        }

        public LicenciadoRepositorio RepositorioLicenciado
        {
            get
            {
                return licenciadoRepositorio = licenciadoRepositorio ?? new LicenciadoRepositorio(_contextLicenciado);
            }
        }
    }
}
