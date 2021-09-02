using System;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class Treina_ClienteValidator : AbstractValidator<Treina_Cliente>
    {
        public Treina_ClienteValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("A entidade não pode ser vazia!!!")
                .NotNull().WithMessage("A entidade não pode ser nula!!!");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF não pode ser vazio!!!")
                .NotNull().WithMessage("O CPF não pode ser nulo!!!")
                .Must(MustFluentValidation.IsCpf).WithMessage("O CPF é inválido!!!");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome não pode ser vazio!!!")
                .NotNull().WithMessage("O nome não pode ser nulo!!!")
                .MinimumLength(4).WithMessage("O nome é muito pequeno!!!")
                .MaximumLength(60).WithMessage("O nome pode conter no máximo 60 caracteres!!!")
                .Matches(@"^[\p{L} \.'\-]+$").WithMessage("O nome não é válido!!!");

            RuleFor(x => x.Dt_Nascimento)
                .NotEmpty().WithMessage("A data de nascimento não pode ser vazia!!!")
                .NotNull().WithMessage("A data de nascimento não pode ser nula")
                .Must(MustFluentValidation.IsMaiorIdade).WithMessage("O cliente deve ser maior de 18 anos!!!")
                .Must(MustFluentValidation.IsIdade).WithMessage("Idade Inválida!!!");

            RuleFor(x => x.Genero)
                .NotEmpty().WithMessage("O gênero não pode ser vazio!!!")
                .NotNull().WithMessage("O gênero não pode ser nulo!!!")
                .Must(MustFluentValidation.IsGenero).WithMessage("O gênero é inválido. Somente 'M' ou 'F'!!!");

            RuleFor(x => x.Vlr_Salario)
                .NotEmpty().WithMessage("O salário não pode ser vazio!!!")
                .NotNull().WithMessage("O salário não pode ser nulo!!!")
                .GreaterThanOrEqualTo(1).WithMessage("O salário tem que ser igual ou maior que 1!!!")
                .LessThanOrEqualTo(999999999999).WithMessage("O salário não pode ter mais que 12 dígitos!!!");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("O logradouro não pode ser vazio!!!")
                .NotNull().WithMessage("O logradouro não pode ser nulo!!!");

            RuleFor(x => x.Numero_Residencia)
                .NotEmpty().WithMessage("A residência não pode ser vazia!!!")
                .NotNull().WithMessage("A residência não pode ser nula!!!");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("O bairro não pode ser vazio!!!")
                .NotNull().WithMessage("O bairro não pode ser nulo!!!");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("A cidade não pode ser vazia!!!")
                .NotNull().WithMessage("A cidade não pode ser nula!!!");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O CEP não pode ser vazio!!!")
                .NotNull().WithMessage("O CEP não pode ser nulo!!!")
                .MinimumLength(8).WithMessage("O Cep é inválido!!!")
                .MaximumLength(8).WithMessage("O Cep é inválido!!!");

            RuleFor(x => x.Usuario_Atualizacao)
                .NotEmpty().WithMessage("O usuário não pode ser vazio!!!")
                .NotNull().WithMessage("O usuário não pode ser nulo!!!");

            RuleFor(x => x.Data_Atualizacao)
                .NotEmpty().WithMessage("A data de atualização não pode ser vazia!!!")
                .NotNull().WithMessage("A data de atualização não pode ser nula!!!");
        }
    }
}