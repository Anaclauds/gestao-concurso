using AppConcurso.Models;
using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppConcurso.Utilitarios
{
    public class Impressora
    {
        // Método para gerar relatório de inscritos
        public async Task GerarRelatorioInscritos(List<RelatorioCandidato> listaInscritos, NavigationManager nav)
        {
            await GerarRelatorio(listaInscritos, "ListaInscritos.frx", "RelatorioInscritos", "Candidatos", nav);
        }

        // Método para gerar relatório de aprovados
        public async Task GerarRelatorioAprovados(List<RelatorioAprovado> listaAprovados, NavigationManager nav)
        {
            await GerarRelatorio(listaAprovados, "ListaAprovados.frx", "RelatorioAprovados", "Aprovados", nav);
        }

        // Método genérico para gerar relatórios
        private async Task GerarRelatorio<T>(List<T> dados, string nomeModelo, string nomeRelatorio, string nomeFonteDados, NavigationManager nav)
        {
            try
            {
                // Caminho do modelo de relatório
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", nomeModelo);

                // Cria o modelo de relatório, se não existir
                if (!File.Exists(filePath))
                {
                    var report = new Report();
                    report.Dictionary.RegisterBusinessObject(dados, nomeFonteDados, 10, true);
                    report.Report.Save(filePath);
                }

                // Carrega o modelo do relatório
                var report1 = new Report();
                report1.Load(filePath);

                // Vincula os dados e prepara o relatório
                report1.Dictionary.RegisterBusinessObject(dados, nomeFonteDados, 10, true);
                report1.Prepare();

                // Exporta para PDF
                using var pdfExport = new PDFSimpleExport();
                using var reportStream = new MemoryStream();
                pdfExport.Export(report1, reportStream);

                // Gera o caminho para o arquivo PDF temporário
                var fileName = $"{nomeRelatorio}_{Guid.NewGuid()}.pdf";
                var filePathTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RelatoriosTemp", fileName);

                // Cria o diretório temporário, caso necessário
                Directory.CreateDirectory(Path.GetDirectoryName(filePathTemp));

                // Salva o arquivo PDF temporário
                File.WriteAllBytes(filePathTemp, reportStream.ToArray());

                // Gera a URL para o arquivo temporário
                var url = nav.ToAbsoluteUri($"/RelatoriosTemp/{fileName}");

                // Abre o relatório em uma nova guia
                nav.NavigateTo(url.ToString(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar o relatório: " + ex.Message);
                throw new Exception("Erro ao gerar relatório: " + ex.Message);
            }
        }
    }
}
