using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class PontuacaoController : Controller
    {
        private readonly ContextoBD _context;

        public PontuacaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Pontuacao>> ListaPontuacoes()
        {
            return await _context.Pontuacoes.Include(x => x.Inscricao).Include(x => x.ConcursoDisciplina).ToListAsync();
        }

        public async Task<ActionResult> Add(Pontuacao pontuacao)
        {
            _context.Pontuacoes.Add(pontuacao);
            await _context.SaveChangesAsync();
            return Ok(pontuacao);
        }

        public async Task<ActionResult<List<Pontuacao>>> ConsultarNotasCandidato(int candidatoId)
        {
            var notas = await _context.Pontuacoes
                .Include(x => x.ConcursoDisciplina)
                .Include(x => x.Inscricao)
                .Where(x => x.Inscricao.IdCandidato == candidatoId)
                .ToListAsync();
            return Ok(notas);
        }

        public async Task<ActionResult<List<Candidato>>> ListaAprovados()
        {
            var aprovados = await _context.Pontuacoes
                .Include(x => x.Inscricao)
                .ThenInclude(x => x.Candidato)
                .GroupBy(x => x.Inscricao.Candidato)
                .Select(g => new
                {
                    Candidato = g.Key,
                    Media = g.Average(x => x.Nota)
                })
                .OrderByDescending(x => x.Media)
                .ToListAsync();

            return Ok(aprovados);
        }
    }
}
