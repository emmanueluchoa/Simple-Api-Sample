using NUnit.Framework;
using SADomain.Entities;
using SADomain.Entities.Enum;
using SADomain.Validators;
using System;
using FluentValidation;

namespace SATests.Entities
{
    public class PessoaTests
    {
        private PessoaValidacao _validacao;

        [SetUp]
        public void Setup() =>
            _validacao = new PessoaValidacao();

        [Test]
        public void ValidarCpfNaoInformado()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", "Gothan", "USA", new DateTime(1978, 04, 17), "bruceWayne@waynecorps.com", string.Empty, Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarCPF");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("Cpf: Cpf não informado.", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarMascaraCpfInvalida()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", "Gothan", "USA", new DateTime(1978, 04, 17), "bruceWayne@waynecorps.com", "12312312312", Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarCPF");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("Cpf: Cpf inválido ou não formatado corretamente. Favor seguir o padrão: ###.###.###-##", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarCpfComLetras()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", "Gothan", "USA", new DateTime(1978, 04, 17), "bruceWayne@waynecorps.com", "abc.abc.abc.ab", Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarCPF");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("Cpf: Cpf inválido ou não formatado corretamente. Favor seguir o padrão: ###.###.###-##", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarEmailInvalido()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", "Gothan", "USA", new DateTime(1978, 04, 17), ".com", "502.761.840-92", Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarEmail");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("Email: Email inválido.", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarNomeNaoInformado()
        {
            Pessoa pessoa = new Pessoa(string.Empty, "Gothan", "USA", new DateTime(1978, 04, 17), "bruceWayne@waynecorps.com", "502.761.840-92", Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarNome");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("Nome: Nome não informado.", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarDataDeNascimentoInvalida()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", "Gothan", "USA", DateTime.Now, "bruceWayne@waynecorps.com", "502.761.840-92", Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarDataDeNascimento");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("DataNascimento: Data de nascimento não pode ser maior que o dia de hoje.", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarDataDeCadastroNaoInformada()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", "Gothan", "USA", new DateTime(1978, 04, 17), "bruceWayne@waynecorps.com", "502.761.840-92", Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarDataDeCadastro");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("_dataDeCadastro: Data de cadastro não informada.", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarDataDeAtualizacaoNaoInformada()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", "Gothan", "USA", new DateTime(1978, 04, 17), "bruceWayne@waynecorps.com", "502.761.840-92", Sexo.Masculino);
            _validacao.CascadeMode = CascadeMode.Stop;

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("ValidarDataDeAtualizacao");
            });

            Assert.False(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual("_dataDeAtualizacao: Data de atualização não informada.", _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarPessoaValidaParaCadastro()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", string.Empty, string.Empty, new DateTime(1978, 04, 17), string.Empty, "502.761.840-92", Sexo.Nao_informado);
            pessoa.DefinirDataDeCadastro();

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("Cadastro");
            });

            Assert.True(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual(string.Empty, _validacao.ListarErrosDeValidacao());
        }

        [Test]
        public void ValidarPessoaValidaParaAtualizacao()
        {
            Pessoa pessoa = new Pessoa("Bruce Wayne", string.Empty, string.Empty, new DateTime(1978, 04, 17), string.Empty, "502.761.840-92", Sexo.Nao_informado);
            pessoa.DefinirDataDeAtualizacao();

            _validacao.ResultadoValidacao = _validacao.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("Atualizar");
            });

            Assert.True(_validacao.ResultadoValidacao.IsValid);
            Assert.AreEqual(string.Empty, _validacao.ListarErrosDeValidacao());

        }
    }
}
