using System.ComponentModel.DataAnnotations;

namespace Refugiados1.Models
{
    public class CriarDadiva
    {
        [Key]
        public int IdCriarDadiva { get; set; }
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Dadiva { get; set; }
        public virtual List<EscolherDadiva> EscolherDadiva { get; set; }
    }
}
