using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("concursoDisciplina")]
    public class ConcursoDisciplina
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("dataRegistro")]
        public DateTime? DataRegistro { get; set; }
        [Column("disciplinaId")]
        public int IdDisciplina { get; set; }
        [Column("concursoId")]
        public int IdConcurso { get; set; }

        [ForeignKey("IdConcurso")]
        public Concurso? Concurso { get; set; }

        [ForeignKey("IdDisciplina")]
        public Disciplina? Disciplina { get; set; }
    }
}
