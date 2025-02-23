using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class PontuacaoController
    {
        private readonly ContextoBD _contexto;

        public PontuacaoController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // Obtém todas as pontuações cadastradas
        public async Task<List<Pontuacao>> ObterTodas()
        {
            return await _contexto.Pontuacoes
                .Include(p => p.Inscricao)
                .Include(p => p.ConcursoDisciplina)
                .AsNoTracking()
                .ToListAsync();
        }

        // Obtém uma pontuação específica pelo ID
        public async Task<Pontuacao> ObterPorId(int id)
        {
            return await _contexto.Pontuacoes
                .Include(p => p.Inscricao)
                .Include(p => p.ConcursoDisciplina)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Adiciona ou atualiza uma pontuação
        public async Task AdicionarOuAtualizar(Pontuacao pontuacao)
        {
            var pontuacaoExistente = await _contexto.Pontuacoes
                .FirstOrDefaultAsync(p => p.IdInscricao == pontuacao.IdInscricao &&
                                          p.IdConcursoDisciplina == pontuacao.IdConcursoDisciplina);

            if (pontuacaoExistente == null)
            {
                // Se não existir, adiciona a pontuação
                _contexto.Pontuacoes.Add(pontuacao);
            }
            else
            {
                // Se já existir, atualiza a nota
                pontuacaoExistente.Nota = pontuacao.Nota;
                _contexto.Pontuacoes.Update(pontuacaoExistente);
            }

            await _contexto.SaveChangesAsync();
        }
    }
}
