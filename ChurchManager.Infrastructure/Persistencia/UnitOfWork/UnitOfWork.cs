using ChurchManager.Infrastructure.Persistencia.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManager.Infrastructure.Persistencia.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CmDbContext _context;

        Repositorios.MembroRepositorio membroRepositorio;
        Repositorios.IgrejaRepositorio igrejaRepositorio;

        public UnitOfWork([FromServices]CmDbContext context)
        {
            _context = context;
        }
        public MembroRepositorio RepositorioMembro
        {
            get
            {
                return membroRepositorio = membroRepositorio ?? new MembroRepositorio(_context);
            }
        }

        public IgrejaRepositorio RepositorioIgreja
        {
            get
            {
                return igrejaRepositorio = igrejaRepositorio ?? new IgrejaRepositorio(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
