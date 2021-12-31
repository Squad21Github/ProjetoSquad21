using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refugiados1.Models
{
    public class AtenderDadiva
    {
        [Key]
        public int IdAtender { get; set; }

        [Required]
        public string Seu_Nome { get; set; }

        [Required]

        public string Telefone { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string CPF { get; set; }

        [ForeignKey("SolicitarDadiva")]
        public int IdDadiva { get; set; }
        public virtual SolicitarDadiva SolicitarDadiva { get; set; }

    }
}
