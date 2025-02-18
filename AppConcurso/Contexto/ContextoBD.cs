using AppConcurso.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Contexto
{
    public class ContextoBD : DbContext
    {
		public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
		{ 
		}

		public DbSet<Candidato> Candidatos { get; set; }
		public DbSet<Cidade> Cidades { get; set; }
		public DbSet<Concurso> Concursos { get; set; }
        public DbSet<ConcursoDisciplina> ConcursosDisciplinas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Pontuacao> Pontuacoes { get; set; }
    }
}

