using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class CidadeController
    {
        private readonly ContextoBD _context;

        public CidadeController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Cidade>> ObterCidadesPorEstado(int estadoId)
        {
            return await _context.Cidades
                .Where(c => c.EstadoId == estadoId)
                .OrderBy(c => c.Municipio)
                .ToListAsync();
        }
    }
}
