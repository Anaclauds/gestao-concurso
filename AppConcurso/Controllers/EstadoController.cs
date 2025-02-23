using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class EstadoController
    {
        private readonly ContextoBD _context;

        public EstadoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Estado>> ListarEstados()
        {
            return await _context.Estados.OrderBy(e => e.Nome).ToListAsync();
        }
    }
}
