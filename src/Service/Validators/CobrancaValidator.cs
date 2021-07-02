using Cobrancas.Domain.Entities;
using Cobrancas.Infra.CrossCutting.Validators;
using FluentValidation;

namespace Cobrancas.Service.Validators
{
    public class CobrancaValidator : AbstractValidator<Cobranca>
    {
        public CobrancaValidator()
        {
            RuleFor(c => c.Vencimento).NotEmpty().NotNull();

            RuleFor(c => c.Valor).NotEmpty().NotNull();

            RuleFor(c => c.CPF).NotEmpty().NotNull()
                .Must(ValidateCPF.CPFIsValid).WithMessage("'CPF' inválido.");
        }

    }
}