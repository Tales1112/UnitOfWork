using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unity_Of_Work.Enums;

namespace Unity_Of_Work.Models
{
    [Table("CLIENTE")]
    public class Client
    {
        public Client(ClientViewModel client)
        {
            this.Nome = client.Nome;
            this.Email = client.Email;
            this.sexo = client.Sexo;
            this.Cpf = client.Cpf;
        }
        public Client()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDCLIENTE")]
        public int ClientId { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("SEXO")]
        public Sexo sexo;

        [Column("Email")]
        public string Email { get; set; }

        [Column("CPF")]
        public string Cpf { get; set; }
    }
}
