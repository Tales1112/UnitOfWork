using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unity_Of_Work.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        public Endereco(EnderecoViewModel endereco)
        {
            this.Rua = endereco.Rua;
            this.Bairro = endereco.Bairro;
            this.Cidade = endereco.Cidade;
            this.Estado = endereco.Estado;
            this.ID_CLIENTE = endereco.ID_CLIENTE;
        }
        public Endereco()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDENDERECO")]
        public int EnderecoId { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public int ID_CLIENTE { get; set; }
    }
}
