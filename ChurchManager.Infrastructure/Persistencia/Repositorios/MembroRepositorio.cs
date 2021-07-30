using ChurchManager.Application.Entidades;
using ChurchManager.Application.Interfaces.Repositorios;
using ChurchManager.Infrastructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Infrastructure.Persistencia.Repositorios
{
    public class MembroRepositorio : Repositorio<Membro>, IMembroRepositorio
    {
        public MembroRepositorio(CmDbContext context)
            : base(context)
        { }
    }
}
