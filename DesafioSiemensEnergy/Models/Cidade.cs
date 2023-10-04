using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioSiemensEnergy.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}
