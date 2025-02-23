using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class ConcursoController
    {
        private readonly ContextoBD _context;

        public ConcursoController(ContextoBD context)
        {
            _context = context;
        }

        // Método para obter todos os concursos
        public async Task<List<Concurso>> ObterTodos()
        {
            return await _context.Concursos.AsNoTracking().ToListAsync();
        }

        // Método para adicionar um novo concurso
        public async Task Add(Concurso concurso)
        {
            _context.Concursos.Add(concurso);
            await _context.SaveChangesAsync();
        }

        // Método para salvar alterações
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        // Método para buscar um concurso pelo ID
        public async Task<Concurso?> ObterPorId(int id)
        {
            return await _context.Concursos.FindAsync(id);
        }
    }
}
