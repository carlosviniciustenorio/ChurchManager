using ChurchManager.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ChurchManager.Domain.Interfaces.Repositorios
{
    public interface IIgrejaRepositorio
    {
        void Add(Igreja entity);
        void Edit(Igreja entity);
        void Remove(Igreja entity);
        Igreja FindById(int id);
        IQueryable<Igreja> FindBy(Expression<Func<Igreja, bool>> predicate);
        IQueryable<Igreja> FindAll();
        void Dispose();
        void Save();
    }
}
