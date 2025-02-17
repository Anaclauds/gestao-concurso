using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ContextoBD _context;

        public CandidatoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Candidato>> ListaCandidatos()
        {
            var candidatos = await _context.Candidatos.Include(x => x.Inscricoes).ToListAsync();
            return candidatos;
        }

        public async Task<ActionResult> Add(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();
            return Ok(candidato);
        }

        public async Task<ActionResult> Salvar()
        {
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Erro ao salvar candidato.");
            }
        }
    }
}