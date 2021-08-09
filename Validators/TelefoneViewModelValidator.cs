using FluentValidation;
using Unity_Of_Work.Extensions;
using Unity_Of_Work.Models;
using Unity_Of_Work.Services.Errors;

namespace Unity_Of_Work.Validators
{
    public class TelefoneViewModelValidator : AbstractValidator<TelefoneViewModel>
    {
        public TelefoneViewModelValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.IdCliente)
                .NotEmpty().WithMessage(UnityOfWorkErrors.Endereco_400_Invalid_ClientId.ToString())
                .NotNull().WithMessage(UnityOfWorkErrors.Endereco_400_Invalid_ClientId.ToString());

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage(UnityOfWorkErrors.Telefone_400_Invalid_Numero.ToString())
                .NotNull().WithMessage(UnityOfWorkErrors.Telefone_400_Invalid_Numero.ToString())
                .Length(11).WithMessage(UnityOfWorkErrors.Telefone_400_Invalid_Numero.ToString())
                .Must(x => x.IsNumber()).WithMessage(UnityOfWorkErrors.Telefone_400_Invalid_Numero.ToString());
        }
    }
}
