using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("pontuacao")]
    public class Pontuacao
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nota")]
        public decimal Nota { get; set; }
        [Column("concursoDisciplinaId")]
        public int IdConcursoDisciplina { get; set; }
        [Column("inscricaoId")]
        public int IdInscricao { get; set; }

        [ForeignKey("IdConcursoDisciplina")]
        public ConcursoDisciplina? ConcursoDisciplina { get; set; }

        [ForeignKey("IdInscricao")]
        public Inscricao? Inscricao { get; set; }
    }
}
