using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("numero_insc")]
        public int? NumeroInsc { get; set; }
        [Column("data_inscricao")]
        public DateTime? DataInscricao { get; set; }
        [Column("nota_conh_gerais")]
        public decimal? NotaConhGerais { get; set; }
        [Column("nota_conh_especificos")]
        public decimal? NotaConhEspecificos { get; set; }

        [Column("candidato_id")]
        public int IdCandidato { get; set; }

        [Column("cargo_id")]
        public int IdCargo { get; set; }

        [ForeignKey("IdCargo")] // informa qual o atributo da classe vai armazenar a FK
        public Cargo? Cargo { get; set; } // indica o cargo

        [ForeignKey("IdCandidato")] // informa qual o atributo da classe vai armazenar a FK
        public Candidato? Candidato { get; set; } // indica o candidato

    }

}