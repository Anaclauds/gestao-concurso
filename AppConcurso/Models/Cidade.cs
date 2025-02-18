using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("cidade")]
    public class Cidade
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("municipio")]
        public string? Municipio { get; set; }
        [Column("estadoId")]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")] // informa qual o atributo da classe vai armazenar a FK
        public Estado? Estado { get; set; } // indica o estado
    }
}
