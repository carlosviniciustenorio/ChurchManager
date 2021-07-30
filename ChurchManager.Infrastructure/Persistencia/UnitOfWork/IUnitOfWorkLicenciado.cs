using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchManager.Infrastructure.Persistencia.UnitOfWork
{
    public interface IUnitOfWorkLicenciado
    {
        Repositorios.LicenciadoRepositorio RepositorioLicenciado { get; }
    }
}