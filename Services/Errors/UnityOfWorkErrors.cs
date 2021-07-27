using System.ComponentModel;

namespace Unity_Of_Work.Services.Errors
{
    public enum UnityOfWorkErrors
    {
        /// <summary>
        /// O nome informado é inválido
        /// </summary>
        [Description]
        Client_AdicionarCliente_Post_400_Invalid_Name,

        /// <summary>
        /// O email informado é inválido
        /// </summary>
        [Description]
        Client_AdicionarCliente_Post_400_Invalid_Email,
    }
}
