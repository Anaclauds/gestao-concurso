using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<ConcursoDisciplina>> ObterTodos()
        {
            return await _contexto.ConcursosDisciplinas.AsNoTracking().ToListAsync();
        }

        public async Task Adicionar(ConcursoDisciplina concursoDisciplina)
        {
            _contexto.ConcursosDisciplinas.Add(concursoDisciplina);
            await _contexto.SaveChangesAsync();
        }
    }
}
