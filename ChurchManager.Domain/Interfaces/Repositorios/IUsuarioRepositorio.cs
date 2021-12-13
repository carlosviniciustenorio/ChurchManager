using ChurchManager.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Add(Usuario entity);
        void Edit(Usuario entity);
        void Remove(Usuario entity);
        Usuario FindById(int id);
        IQueryable<Usuario> FindBy(Expression<Func<Usuario, bool>> predicate);
        IQueryable<Usuario> FindAll();
        void Dispose();
        void Save();
    }
}
