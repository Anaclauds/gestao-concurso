using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
		[Table("cargo")]
		public class Cargo
		{
			[Column("id")]
			public int Id { get; set; }
			[Column("nome_cargo")]
			public string? NomeCargo { get; set; }
			[Column("edital")]
			public string? Edital { get; set; }
			[Column("salario_base")]
			public decimal? SalarioBase { get; set; }

			public List<Inscricao> Inscricoes { get; set; } //Chama a lista para o controller
		}
}
