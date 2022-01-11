using System.ComponentModel.DataAnnotations;

namespace Refugiados1.Models
{
    public class SolicitarDadiva
    {
        [Key]
        public int IdDadiva { get; set; }
        [Required]
        public string Ong { get; set; }

        [Required]
        public string Endereço { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Dádiva { get; set; }

        public virtual List<AtenderDadiva> AtenderDadiva { get; set; }
    }
}
