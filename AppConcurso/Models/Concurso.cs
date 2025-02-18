using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
	[Table("concurso")]
		public class Concurso
		{
			[Column("id")]
			public int Id { get; set; }
			[Column("edital")]
			public string? Edital { get; set; }
			[Column("dataConcurso")]
			public DateTime? DataConcurso { get; set; }

			public List<Inscricao> Inscricoes { get; set; } // Chama a lista para o controller
		}
}
