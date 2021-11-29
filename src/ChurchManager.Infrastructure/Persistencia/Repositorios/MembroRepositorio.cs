using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ChurchManager.Infrastructure.Persistencia.Repositorios
{
    public class MembroRepositorio : Repositorio<Membro>, IMembroRepositorio
    {
        public MembroRepositorio(CmDbContext context)
            : base(context)
        { }
    }
}
