using FluentValidation;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Application.UseCases.Validations
{
    public class FinantialProductValidator : AbstractValidator<FinantialProduct>
    {
        public FinantialProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do produto não pode ser vazio")
                .MaximumLength(100).WithMessage("O nome do produto não pode ter mais de 100 caracteres");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero");

            RuleFor(p => p.Type)
                .IsInEnum().WithMessage("O tipo do produto deve ser válido");


        }
    }
}
