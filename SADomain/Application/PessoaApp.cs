using FluentValidation;
using SADomain.Entities;
using SADomain.Interfaces.Application;
using SADomain.Interfaces.Repository;
using SADomain.Validators;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SADomain.Application
{
    public class PessoaApp : IPessoaApp
    {
        private readonly IPessoaRepository _pessoaRepository;
        private PessoaValidacao _pessoaValidacao;

        public PessoaApp(IPessoaRepository pessoaRepository)
        {
            this._pessoaRepository = pessoaRepository;

            if (null == _pessoaValidacao)
                _pessoaValidacao = new PessoaValidacao();
        }

        public void Atualizar(Pessoa pessoa)
        {
            pessoa.DefinirDataDeAtualizacao();
            _pessoaValidacao.ResultadoValidacao = _pessoaValidacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("Atualizar");
            });

            if (_pessoaValidacao.ResultadoValidacao.IsValid)
                _pessoaRepository.Atualizar(pessoa);
        }

        public IList<Pessoa> Buscar(Expression<Func<Pessoa, bool>> predicate) =>
            _pessoaRepository.Buscar(predicate);

        public Pessoa BuscarPeloId(string id) =>
            _pessoaRepository.Buscar(id);

        public void Cadastrar(Pessoa pessoa)
        {
            pessoa.DefinirDataDeCadastro();
            _pessoaValidacao.ResultadoValidacao = _pessoaValidacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("Cadastro");
            });

            if (_pessoaValidacao.ResultadoValidacao.IsValid)
                _pessoaRepository.Cadastrar(pessoa);
        }

        public void Excluir(string id)
        {
            Pessoa pessoa = _pessoaRepository.Buscar(id);

            if (null != pessoa)
                _pessoaRepository.Excluir(id);
        }

        public IList<Pessoa> Listar() =>
            _pessoaRepository.Listar();
    }
}
