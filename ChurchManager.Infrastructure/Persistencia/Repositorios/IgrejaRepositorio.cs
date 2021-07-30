using ChurchManager.Domain.Entidades;
using ChurchManager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Infrastructure.Persistencia.Repositorios
{
    public class IgrejaRepositorio : Repositorio<Igreja>, IIgrejaRepositorio
    {
        public IgrejaRepositorio(CmDbContext context) : base(context)
        { }
    }
}
