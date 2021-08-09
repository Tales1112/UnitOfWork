using System.ComponentModel;

namespace Unity_Of_Work.Services.Errors
{
    public enum UnityOfWorkErrors
    {
        /// <summary>
        /// O nome informado é inválido
        /// </summary>
        [Description]
        Client_400_Invalid_Name,

        /// <summary>
        /// O email informado é inválido
        /// </summary>
        [Description]
        Client_400_Invalid_Email,

        /// <summary>
        /// O cpf informado é inválido
        /// </summary>
        [Description]
        Client_400_Invalid_CPF,

        /// <summary>
        /// O bairro informado é inválido
        /// </summary>
        [Description]
        Endereco_400_Invalid_Bairro,

        /// <summary>
        /// A rua informada é inválida
        /// </summary>
        [Description]
        Endereco_400_Invalid_Rua,

        /// <summary>
        /// A cidade informada é inválida
        /// </summary>
        [Description]
        Endereco_400_Invalid_Cidade,

        /// <summary>
        /// O Estado informado é inválido
        /// </summary>
        [Description]
        Endereco_400_Invalid_Estado,

        /// <summary>
        /// O clientId informado é inválido
        /// </summary>
        [Description]
        Endereco_400_Invalid_ClientId,

        /// <summary>
        /// O numero informado é inválido
        /// </summary>
        [Description]
        Telefone_400_Invalid_Numero,

        /// <summary>
        /// O id do cliente informado é inválido
        /// </summary>
        [Description]
        Telefone_400_Invalid_IdCliente,

        /// <summary>
        /// O tipoDoNumero do cleinte informado é inválido
        /// </summary>
        [Description]
        Telefone_400_Invalid_Tipo
    }
}
