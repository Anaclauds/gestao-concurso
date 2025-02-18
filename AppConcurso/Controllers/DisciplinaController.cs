using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly ContextoBD _context;

        public DisciplinaController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Disciplina>> ListaDisciplinas()
        {
            return await _context.Disciplinas.ToListAsync();
        }

        public async Task<ActionResult> Add(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            await _context.SaveChangesAsync();
            return Ok(disciplina);
        }
    }
}
