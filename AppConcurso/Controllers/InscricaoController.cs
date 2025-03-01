using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class InscricaoController
    {
        private readonly ContextoBD _context;

        public InscricaoController(ContextoBD context)
        {
            _context = context;
        }

        // Adiciona uma nova inscrição ao banco de dados
        public async Task Add(Inscricao inscricao)
        {
            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();
        }

        // Obtém a lista de concursos em que um candidato está inscrito
        public async Task<List<Concurso>> ObterConcursosPorCandidato(int candidatoId)
        {
            return await _context.Inscricoes
                .Where(i => i.CandidatoId == candidatoId)
                .Include(i => i.Concurso)
                .Select(i => i.Concurso)
                .ToListAsync();
        }
    }
}
