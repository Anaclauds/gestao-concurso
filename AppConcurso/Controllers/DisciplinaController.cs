using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class DisciplinaController
    {
        private readonly ContextoBD _contexto;

        public DisciplinaController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Disciplina>> ObterTodas()
        {
            return await _contexto.Disciplinas.AsNoTracking().ToListAsync();
        }

        public async Task<int> Adicionar(Disciplina disciplina)
        {
            _contexto.Disciplinas.Add(disciplina);
            await _contexto.SaveChangesAsync();
            return disciplina.Id; // Retorna o ID gerado para a disciplina
        }
    }
}
