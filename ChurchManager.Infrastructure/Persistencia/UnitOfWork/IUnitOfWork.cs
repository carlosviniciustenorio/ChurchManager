namespace ChurchManager.Infrastructure.Persistencia.UnitOfWork
{
    public interface IUnitOfWork
    {
        Repositorios.MembroRepositorio RepositorioMembro { get; }
        void Save();
    }
}