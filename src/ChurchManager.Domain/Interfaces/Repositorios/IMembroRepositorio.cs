using ChurchManager.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ChurchManager.Domain.Interfaces.Repositorios
{
    public interface IMembroRepositorio
    {
        void Add(Membro entity);
        void Edit(Membro entity);
        void Remove(Membro entity);
        Membro FindById(int id);
        IQueryable<Membro> FindBy(Expression<Func<Membro, bool>> predicate);
        IQueryable<Membro> FindAll();
        void Dispose();
        void Save();
    }
}