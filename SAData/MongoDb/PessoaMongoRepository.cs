using MongoDB.Driver;
using SADomain.Entities;
using SADomain.Interfaces.Repository;
using SADomain.Interfaces.Repository.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SAData.MongoDb
{
    public class PessoaMongoRepository : IPessoaRepository
    {
        private readonly string _nomeColecao = "Pessoas";
        private readonly IMongoCollection<Pessoa> _pessoas;
        private readonly IMongoDbConfig _mongoDbConfig;

        public PessoaMongoRepository(IMongoDbConfig mongoDbConfig)
        {
            this._mongoDbConfig = mongoDbConfig;

            MongoClient mongoClient = new MongoClient(mongoDbConfig.CaminhoDaConexao);
            var bancoDeDados = mongoClient.GetDatabase(mongoDbConfig.NomeDoBanco);

            _pessoas = bancoDeDados.GetCollection<Pessoa>(_nomeColecao);
        }

        public Pessoa Atualizar(Pessoa obj)
        {
            throw new NotImplementedException();
        }

        public Pessoa Buscar(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Pessoa> Buscar(Expression<Func<Pessoa, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pessoa obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Pessoa> Listar() =>
            _pessoas.Find(pessoa => true).ToList();
    }
}
