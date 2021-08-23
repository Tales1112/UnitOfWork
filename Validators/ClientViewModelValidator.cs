using FluentValidation;
using Unity_Of_Work.Extensions;
using Unity_Of_Work.Models;
using Unity_Of_Work.Services.Errors;

namespace Unity_Of_Work.Validators
{
    public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
    {
        public ClientViewModelValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(n => n.Nome)
                .NotNull().WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_Name.ToString())
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_Name.ToString());

            RuleFor(n => n.Email)
                .NotNull().WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_Email.ToString())
                .NotNull().WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_Email.ToString())
                .EmailAddress().WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_Email.ToString());

            RuleFor(n => n.Cpf)
                .NotNull().WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_CPF.ToString())
                .Must(x => x.IsCpf()).WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_CPF.ToString())
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Client_400_Invalid_CPF.ToString());
        }
    }
}
