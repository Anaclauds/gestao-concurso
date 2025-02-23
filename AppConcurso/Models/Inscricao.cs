using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("dataInscricao")]
        public DateTime DataInscricao { get; set; }

        [Column("candidatoId")]
        public int CandidatoId { get; set; }

        [Column("concursoId")]
        public int ConcursoId { get; set; }

        [ForeignKey("ConcursoId")]
        public Concurso? Concurso { get; set; }

        [ForeignKey("CandidatoId")]
        public Candidato? Candidato { get; set; }
    }
}
