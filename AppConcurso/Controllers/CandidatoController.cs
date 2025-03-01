using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppConcurso.Controllers
{
    public class CandidatoController
    {
        private readonly ContextoBD _context;

        public CandidatoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Candidato>> ObterTodosCandidatos()
        {
            return await _context.Candidatos.OrderBy(c => c.Nome).ToListAsync();
        }


        // Lista todos os candidatos cadastrados
        public async Task<List<Candidato>> ListaCandidatos()
        {
            return await _context.Candidatos.ToListAsync();
        }

        // Obtém um candidato específico pelo ID
        public async Task<Candidato> ObterPorId(int id)
        {
            return await _context.Candidatos.FindAsync(id);
        }

        // Obtém todos os concursos disponíveis
        public async Task<List<Concurso>> ObterTodosConcursos()
        {
            return await _context.Concursos.AsNoTracking().ToListAsync();
        }

        // Adiciona um novo candidato e vincula ao concurso escolhido
        public async Task CadastrarCandidatoComInscricao(Candidato candidato, int concursoId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Gerar número de inscrição automaticamente
                int ultimoNumero = await _context.Candidatos.MaxAsync(c => (int?)c.NumeroInscricao) ?? 0;
                candidato.NumeroInscricao = ultimoNumero + 1;

                _context.Candidatos.Add(candidato);
                await _context.SaveChangesAsync();

                // Criar inscrição vinculando o candidato ao concurso e definindo a data atual
                var inscricao = new Inscricao
                {
                    CandidatoId = candidato.Id,
                    ConcursoId = concursoId,
                    DataInscricao = DateTime.Now // Preenche automaticamente com a data do sistema
                };

                _context.Inscricoes.Add(inscricao);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }
        // Obtém Concursos por Candidatos
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
