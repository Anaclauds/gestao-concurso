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
        public int Ativo { get; set; }
        [Column("candidatoId")]
        public int IdCandidato { get; set; }
        [Column("cidadeId")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCandidato")] 
        public Candidato? Candidato { get; set; } 

        [ForeignKey("IdCidade")] 
        public Cidade? Cidade { get; set; }
    }
}
