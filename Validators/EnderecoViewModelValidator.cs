using FluentValidation;
using Unity_Of_Work.Models;
using Unity_Of_Work.Services.Errors;

namespace Unity_Of_Work.Validators
{
    public class EnderecoViewModelValidator : AbstractValidator<EnderecoViewModel>
    {
        public EnderecoViewModelValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Bairro)
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Bairro.ToString())
                .NotNull().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Bairro.ToString());

            RuleFor(x => x.Cidade)
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Cidade.ToString())
                .NotNull().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Cidade.ToString());

            RuleFor(x => x.Estado)
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Estado.ToString())
                .NotNull().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Estado.ToString());

            RuleFor(x => x.Rua)
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Rua.ToString())
                .NotNull().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_Rua.ToString());

            RuleFor(x => x.ID_CLIENTE)
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_ClientId.ToString())
                .NotNull().WithErrorCode(UnityOfWorkErrors.Endereco_400_Invalid_ClientId.ToString());
        }
    }
}
