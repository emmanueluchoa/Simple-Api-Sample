using SADomain.Entities.Enum;
using System;

namespace SADomain.Entities
{
    public class Pessoa
    {
        public Pessoa(string nome, string naturalidade, string nacionalidade, DateTime dataNascimento, string email, string cpf, Sexo sexo = Sexo.Nao_informado)
        {
            if (string.IsNullOrWhiteSpace(Id))
                Id = Guid.NewGuid().ToString();

            Nome = nome;
            Sexo = sexo;
            Naturalidade = naturalidade;
            Nacionalidade = nacionalidade;
            DataNascimento = dataNascimento;
            Email = email;
            Cpf = cpf;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public Sexo Sexo { get; private set; }
        public string Naturalidade { get; private set; }
        public string Nacionalidade { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? _dataDeCadastro { get; private set; }
        public DateTime? _dataDeAtualizacao { get; private set; }

        public void DefinirDataDeCadastro() =>
            this._dataDeCadastro = DateTime.Now;

        public void DefinirDataDeAtualizacao() =>
            this._dataDeAtualizacao = DateTime.Now;
    }
}
