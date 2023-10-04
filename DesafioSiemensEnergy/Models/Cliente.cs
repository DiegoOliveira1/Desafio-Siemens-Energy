using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioSiemensEnergy.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Column("Nascimento")]
        [Display(Name = "Nascimento")]
        public string Nascimento { get; set; }

        [Column("Idade")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
    }
}
