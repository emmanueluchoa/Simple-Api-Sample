using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SADomain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        T Atualizar(T obj);
        T Buscar(string id);
        IList<T> Buscar(Expression<Func<T, bool>> predicate);
        void Cadastrar(T obj);
        void Excluir(string id);
        IList<T> Listar();
    }
}
