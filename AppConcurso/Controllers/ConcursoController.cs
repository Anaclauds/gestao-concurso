using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class ConcursoController : Controller
    {
        private readonly ContextoBD _context;

        public ConcursoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Concurso>> ListaConcursos()
        {
            return await _context.Concursos.ToListAsync();
        }

        public async Task<ActionResult> Add(Concurso concurso)
        {
            _context.Concursos.Add(concurso);
            await _context.SaveChangesAsync();
            return Ok(concurso);
        }
    }
}
