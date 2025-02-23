using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    [Table("endereco")]
    public class Endereco
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("rua")]
        public string? Rua { get; set; }

        [Column("numero")]
        public string? Numero { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; } // Alterado para bool

        [Column("candidatoId")]
        public int CandidatoId { get; set; }

        [Column("cidadeId")]
        public int CidadeId { get; set; }

        [ForeignKey("CandidatoId")]
        public Candidato? Candidato { get; set; }

        [ForeignKey("CidadeId")]
        public Cidade? Cidade { get; set; }
    }
}
