using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("inscricao")]
        public class Inscricao
        {
            [Column("id")]
            public int Id { get; set; }
            [Column("dataInscricao")]
            public DateTime? DataInscricao { get; set; }
            [Column("candidadoId")]
            public int IdCandidato { get; set; }
            [Column("concursoId")]
            public int IdConcurso { get; set; }

            [ForeignKey("IdConcurso")] 
            public Concurso? Concurso { get; set; } 

            [ForeignKey("IdCandidato")] 
            public Candidato? Candidato { get; set; }
        }
}