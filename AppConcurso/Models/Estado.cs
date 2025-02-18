using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("estado")]
    public class Estado
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("regiao")]
        public string? Regiao { get; set; }
        [Column("uf")]
        public string? Uf { get; set; }
    }
}
