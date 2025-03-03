﻿using AppConcurso.Contexto;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        // Retorna as disciplinas vinculadas a um concurso específico
        public async Task<List<ConcursoDisciplina>> ObterDisciplinasPorConcurso(int concursoId)
        {
            return await _contexto.ConcursosDisciplinas
                .Where(cd => cd.ConcursoId == concursoId)
                .Include(cd => cd.Disciplina)
                .AsNoTracking()
                .ToListAsync();
        }

        // Retorna a Inscrição do candidato para aquele concurso
        public async Task<int> ObterInscricaoId(int candidatoId, int concursoId)
        {
            var inscricao = await _contexto.Inscricoes
                .Where(i => i.CandidatoId == candidatoId && i.ConcursoId == concursoId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return inscricao?.Id ?? 0; // Retorna 0 se não encontrar
        }

        // Salva a nota do candidato na disciplina do concurso
        public async Task SalvarPontuacao(Pontuacao pontuacao)
        {
            _contexto.Pontuacoes.Add(pontuacao);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Pontuacao>> ObterNotasPorInscricao(int inscricaoId)
        {
            return await _contexto.Pontuacoes
                .Where(p => p.IdInscricao == inscricaoId)
                .Include(p => p.Inscricao)
                    .ThenInclude(i => i.Concurso)
                .Include(p => p.ConcursoDisciplina)
                    .ThenInclude(cd => cd.Disciplina)
                .ToListAsync();
        }

        public async Task<List<Pontuacao>> ObterNotasPorCandidato(int candidatoId)
        {
            return await _contexto.Pontuacoes
                .Include(p => p.Inscricao)
                    .ThenInclude(i => i.Concurso) // Para acessar o concurso
                .Include(p => p.ConcursoDisciplina)
                    .ThenInclude(cd => cd.Disciplina) // Para acessar a disciplina
                .Where(p => p.Inscricao.CandidatoId == candidatoId) // Filtra pelo candidato correto
                .ToListAsync();
        }


        public async Task<List<AprovadoDTO>> ObterAprovadosPorConcurso(int concursoId)
        {
            var candidatosComNotas = await _contexto.Pontuacoes
                .Where(p => p.ConcursoDisciplina.ConcursoId == concursoId)
                .Include(p => p.Inscricao).ThenInclude(i => i.Candidato)
                .GroupBy(p => p.Inscricao.CandidatoId)
                .Select(g => new AprovadoDTO
                {
                    Nome = g.First().Inscricao.Candidato.Nome,
                    Media = g.Average(p => p.Nota)
                })
                .OrderByDescending(a => a.Media)
                .ToListAsync();

            return candidatosComNotas;
        }

        // Obtendo relatório de aprovados
        public async Task<List<RelatorioAprovado>> ObterRelatorioAprovados(int concursoId)
        {
            // Agrupa as pontuações por inscrição e calcula a média
            var aprovados = await _contexto.Pontuacoes
                .Include(p => p.Inscricao)
                .ThenInclude(i => i.Candidato)
                .Where(p => p.Inscricao.ConcursoId == concursoId)
                .GroupBy(p => new
                {
                    p.Inscricao.Candidato.Nome,
                    p.Inscricao.Candidato.Id
                })
                .Select(g => new RelatorioAprovado
                {
                    NomeCandidato = g.Key.Nome,
                    Media = g.Average(p => (double)p.Nota), // Calcula a média
                    Posicao = 0, // A posição será atribuída posteriormente
                    EditalConcurso = g.FirstOrDefault().Inscricao.Concurso.Edital
                })
                .OrderByDescending(r => r.Media) // Ordena pela média decrescente
                .ToListAsync();

            // Atribui a posição de cada aprovado
            for (int i = 0; i < aprovados.Count; i++)
            {
                aprovados[i].Posicao = i + 1; // Define a posição
            }

            return aprovados;
        }



    }
}
