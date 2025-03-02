using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("concursodisciplina")]
    public class ConcursoDisciplina
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("dataRegistro")]
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        [Column("disciplinaId")]
        public int DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }

        [Column("concursoId")]
        public int ConcursoId { get; set; }
        public Concurso? Concurso { get; set; }
    }
}
