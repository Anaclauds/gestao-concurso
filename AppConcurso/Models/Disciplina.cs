using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("disciplina")]
    public class Disciplina
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("disciplina")]
        public string? Nome { get; set; }
    }
}
