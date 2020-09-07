using SADomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SADomain.Interfaces.Application
{
    public interface IPessoaApp
    {
        void Atualizar(Pessoa pessoa);
        IList<Pessoa> Buscar(Expression<Func<Pessoa, bool>> predicate);
        Pessoa BuscarPeloId(string id);
        void Cadastrar(Pessoa pessoa);
        void Excluir(string id);
        IList<Pessoa> Listar();
    }
}
