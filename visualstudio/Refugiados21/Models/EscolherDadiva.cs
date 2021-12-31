using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refugiados1.Models
{
    public class EscolherDadiva
    {
        [Key]
        public int IdEscolherDadiva { get; set; }

        [Required]
        public string Ong { get; set; }

        [Required]

        public string Endereço { get; set; }

        [Required]

        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("CriarDadiva")]
        public int IdCriarDadiva { get; set; }
        public virtual CriarDadiva CriarDadiva { get; set; }
    }
}
