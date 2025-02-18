using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly ContextoBD _context;

        public InscricaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Inscricao>> ListaInscricoes()
        {
            return await _context.Inscricoes.Include(x => x.Candidato).Include(x => x.Concurso).ToListAsync();
        }

        public async Task<ActionResult> Add(Inscricao inscricao)
        {
            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();
            return Ok(inscricao);
        }

        public async Task<ActionResult<List<Inscricao>>> ConsultarPorCandidato(int candidatoId)
        {
            var inscricoes = await _context.Inscricoes
                .Where(x => x.IdCandidato == candidatoId)
                .Include(x => x.Concurso)
                .ToListAsync();
            return Ok(inscricoes);
        }
    }
}
