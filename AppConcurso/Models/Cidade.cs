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
        public int EstadoId { get; set; } // 🔹 Nome ajustado para seguir a convenção do EF

        [ForeignKey("EstadoId")] // 🔹 Ajustado para corresponder ao nome correto
        public Estado? Estado { get; set; }
    }
}
