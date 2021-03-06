using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class Treina_PropostaValidator : AbstractValidator<Treina_Proposta>
    {
        public Treina_PropostaValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("A entidade não pode ser vazia!!!")
                .NotNull().WithMessage("A entidade não pode ser nula!!!");

            RuleFor(x => x.Proposta)
                .NotNull().WithMessage("A proposta não pode ser nula!!!")
                .GreaterThanOrEqualTo(0).WithMessage("O número da proposta tem que ser igual ou maior que 0!!!")
                .LessThanOrEqualTo(9999999999).WithMessage("O número da proposta não pode ter mais que 10 dígitos!!!");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF não pode ser vazio!!!")
                .NotNull().WithMessage("O CPF não pode ser nulo!!!")
                .Must(MustFluentValidation.IsCpf).WithMessage("O CPF é inválido!!!");

            RuleFor(x => x.Conveniada)
                .NotEmpty().WithMessage("A conveniada não pode ser vazia!!!")
                .NotNull().WithMessage("A conveniada pode ser nula!!!")
                .MaximumLength(6).WithMessage("A conveniada pode conter no máximo 6 caracteres!!!");

            RuleFor(x => x.Vlr_Solicitado)
                .NotEmpty().WithMessage("O valor solicitado não pode ser vazio!!!")
                .NotNull().WithMessage("O valor solicitado não pode ser nulo!!!")
                .GreaterThanOrEqualTo(1).WithMessage("O valor solicitado tem que ser igual ou maior que 1!!!")
                .LessThanOrEqualTo(999999999999).WithMessage("O valor solicitado não pode ter mais que 12 dígitos!!!");

            RuleFor(x => x.Prazo)
                .NotNull().WithMessage("O prazo não pode ser nulo!!!")
                .GreaterThanOrEqualTo(1).WithMessage("O prazo tem que ser igual ou maior que 1!!!")
                .LessThanOrEqualTo(99).WithMessage("O prazo não pode ser maior que 99!!!");

            RuleFor(x => x.Vlr_Financiado)
                .NotEmpty().WithMessage("O valor financiado não pode ser vazio!!!")
                .NotNull().WithMessage("O valor financiado não pode ser nulo!!!")
                .GreaterThanOrEqualTo(1).WithMessage("O valor financiado tem que ser igual ou maior que 1!!!")
                .LessThanOrEqualTo(999999999999).WithMessage("O valor financiado não pode ter mais que 12 dígitos!!!");

            RuleFor(x => x.Situacao)
                .NotEmpty().WithMessage("O logradouro não pode ser vazio!!!")
                .NotNull().WithMessage("O logradouro não pode ser nulo!!!")
                .Must(MustFluentValidation.IsSituacao).WithMessage("A situação é inválida!!!");;

            RuleFor(x => x.Usuario)
                .NotEmpty().WithMessage("O usuário não pode ser vazio!!!")
                .NotNull().WithMessage("O usuário não pode ser nulo!!!")
                .MaximumLength(10).WithMessage("O usuário pode conter no máximo 10 caracteres!!!");

            RuleFor(x => x.Usuario_Atualizacao)
                .NotEmpty().WithMessage("O usuário não pode ser vazio!!!")
                .NotNull().WithMessage("O usuário não pode ser nulo!!!");

            RuleFor(x => x.Data_Atualizacao)
                .NotEmpty().WithMessage("A data de atualização não pode ser vazia!!!")
                .NotNull().WithMessage("A data de atualização não pode ser nula!!!");
        }
    }
}