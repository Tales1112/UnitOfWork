using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unity_Of_Work.Enums;

namespace Unity_Of_Work.Models
{
    [Table("TELEFONE")]
    public class Telefone
    {
        public Telefone(TelefoneViewModel telefoneViewModel)
        {
            this.Numero = telefoneViewModel.Numero;
            this.IdCliente = telefoneViewModel.IdCliente;
            this.TipoNumero = telefoneViewModel.TipoNumero;
        }
        public Telefone()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDTELEFONE")]
        public int IdTelefone { get; set; }

        public string Numero { get; set; }

        public int IdCliente { get; set; }

        public Numero TipoNumero { get; set; }
    }
}
