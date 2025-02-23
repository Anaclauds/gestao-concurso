using AppConcurso.Contexto;
using AppConcurso.Models;
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

        public async Task Add(Inscricao inscricao)
        {
            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();
        }
    }
}
