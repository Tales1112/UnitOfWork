using Unity_Of_Work.Enums;

namespace Unity_Of_Work.Models
{
    public class ClientViewModel
    {
        public ClientViewModel(string nome, string email, string cpf, Sexo sexo)
        {
            this.Nome = nome;
            this.Email = email;
            this.Cpf = cpf;
            this.Sexo = sexo;
        }
        public ClientViewModel()
        {

        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Sexo Sexo { get; set; }
        public string Cpf { get; set; }
    }
}
