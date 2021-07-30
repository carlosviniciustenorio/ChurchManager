using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Infrastructure.Persistencia.UnitOfWork
{
    public interface IUnitOfWork
    {
        Repositorios.MembroRepositorio RepositorioMembro { get; }
        Repositorios.IgrejaRepositorio RepositorioIgreja { get; }
        void Save();
    }
}