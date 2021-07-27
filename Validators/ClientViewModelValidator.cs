using FluentValidation;
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
                .NotNull().WithErrorCode(UnityOfWorkErrors.Client_AdicionarCliente_Post_400_Invalid_Name.ToString())
                .NotEmpty().WithErrorCode(UnityOfWorkErrors.Client_AdicionarCliente_Post_400_Invalid_Name.ToString());
        }
    }
}
