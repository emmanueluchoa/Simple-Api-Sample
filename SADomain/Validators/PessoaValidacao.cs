using FluentValidation;
using FluentValidation.Results;
using SADomain.Entities;
using System;
using System.Linq;

namespace SADomain.Validators
{
    public class PessoaValidacao : AbstractValidator<Pessoa>
    {
        public ValidationResult ResultadoValidacao { get; set; }
        private readonly string cpfMascaraRegex = @"\d{3}\.\d{3}\.\d{3}\-\d{2}";

        public PessoaValidacao()
        {
            RuleSet("Cadastro", () =>
            {
                ValidarCPF();
                ValidarNome();
                ValidarEmail();
                ValidarDataDeCadastro();
                ValidarDataDeNascimento();
            });

            RuleSet("Atualizar", () =>
            {
                ValidarId();
                ValidarCPF();
                ValidarNome();
                ValidarEmail();
                ValidarDataDeNascimento();
                ValidarDataDeAtualizacao();
            });

            RuleSet("ValidarId", () =>
            {
                ValidarId();
            });

            RuleSet("ValidarCPF", () =>
            {
                ValidarCPF();
            });

            RuleSet("ValidarNome", () =>
            {
                ValidarNome();
            });

            RuleSet("ValidarEmail", () =>
            {
                ValidarEmail();
            });

            RuleSet("ValidarDataDeCadastro", () =>
            {
                ValidarDataDeCadastro();
            });

            RuleSet("ValidarDataDeNascimento", () =>
            {
                ValidarDataDeNascimento();
            });

            RuleSet("ValidarDataDeAtualizacao", () =>
            {
                ValidarDataDeAtualizacao();
            });
        }

        void ValidarId()
        {
            RuleFor(pessoa => pessoa.Id)
                .NotEmpty().WithMessage("Id não informado.");
        }

        void ValidarCPF()
        {
            RuleFor(pessoa => pessoa.Cpf)
                .NotEmpty().WithMessage("Cpf não informado.")
                .Matches(cpfMascaraRegex).WithMessage("Cpf inválido ou não formatado corretamente. Favor seguir o padrão: ###.###.###-##");
        }

        void ValidarNome()
        {
            RuleFor(pessoa => pessoa.Nome)
                .NotEmpty().WithMessage("Nome não informado.");
        }

        void ValidarEmail()
        {
            RuleFor(pessoa => pessoa.Email)
                .EmailAddress().When(pessoa => !string.IsNullOrWhiteSpace(pessoa.Email)).WithMessage("Email inválido.");
        }

        void ValidarDataDeCadastro()
        {
            RuleFor(pessoa => pessoa._dataDeCadastro)
                .NotEmpty().WithMessage("Data de cadastro não informada.");
        }

        void ValidarDataDeNascimento()
        {
            RuleFor(pessoa => pessoa.DataNascimento)
                .NotEmpty().WithMessage("Data de nascimento não informada.")
                .LessThan(DateTime.Now).WithMessage("Data de nascimento não pode ser maior que o dia de hoje.");
        }

        void ValidarDataDeAtualizacao()
        {
            RuleFor(pessoa => pessoa._dataDeAtualizacao)
                .NotEmpty().WithMessage("Data de atualização não informada.");
        }

        public string ListarErrosDeValidacao() =>
            string.Join(", ", ResultadoValidacao.Errors.Select(erro => $"{erro.PropertyName}: {erro.ErrorMessage}"));
    }
}