using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class ConcursoDisciplinaController
    {
        private readonly ContextoBD _contexto;

        public ConcursoDisciplinaController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // Obtém todas as disciplinas vinculadas a concursos
        public async Task<List<ConcursoDisciplina>> ObterTodos()
        {
            return await _contexto.ConcursosDisciplinas
                .AsNoTracking()
                .Include(cd => cd.Concurso)   // Inclui informações do concurso
                .Include(cd => cd.Disciplina) // Inclui informações da disciplina
                .ToListAsync();
        }

        // Adiciona uma nova relação entre concurso e disciplina
        public async Task Adicionar(ConcursoDisciplina concursoDisciplina)
        {
            _contexto.ConcursosDisciplinas.Add(concursoDisciplina);
            await _contexto.SaveChangesAsync();
        }

        // Obtém disciplinas vinculadas a um concurso específico
        public async Task<List<Disciplina>> ObterDisciplinasPorConcurso(int concursoId)
        {
            return await _contexto.ConcursosDisciplinas
                .Where(cd => cd.ConcursoId == concursoId)
                .Include(cd => cd.Disciplina)
                .Select(cd => cd.Disciplina)
                .ToListAsync();
        }
    }
}
