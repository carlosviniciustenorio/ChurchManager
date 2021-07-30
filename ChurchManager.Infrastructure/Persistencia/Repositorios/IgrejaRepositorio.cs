using ChurchManager.Application.Entidades;
using ChurchManager.Application.Interfaces.Repositorios;
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
