using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
	[Table("candidato")]
		public class Candidato
		{
			[Column("id")]
			public int Id { get; set; }
			[Column("numeroInscricao")]
			public int NumeroInscricao { get; set; }
			[Column("nome")]
			public string? Nome { get; set; }
			[Column("cpf")]
			public string? Cpf { get; set; }
			
			public List<Inscricao> Inscricoes { get; set; } // Chama a lista para o controller
		}
}
