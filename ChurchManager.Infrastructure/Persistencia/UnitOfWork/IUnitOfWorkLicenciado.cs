namespace ChurchManager.Infrastructure.Persistencia.UnitOfWork
{
    public interface IUnitOfWorkLicenciado
    {
        Repositorios.LicenciadoRepositorio RepositorioLicenciado { get; }
    }
}