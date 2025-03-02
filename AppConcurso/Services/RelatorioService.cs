using AppConcurso.Models;
using FastReport;
using FastReport.Export.PdfSimple;
using FastReport.Data;
using System.Collections.Generic;
using System.IO;

namespace AppConcurso.Services
{
    public class RelatorioService
    {
        public byte[] GerarRelatorio(List<InscricaoRelatorioDTO> inscricoes)
        {
            Report report = new Report();

            // Carrega o template do relatório (crie um arquivo .frx no FastReport)
            report.Load("wwwroot/relatorios/ListaInscritos.frx");

            // Cria a tabela no relatório
            report.RegisterData(inscricoes, "Inscricoes");
            report.GetDataSource("Inscricoes").Enabled = true;

            // Prepara o relatório
            report.Prepare();

            // Exporta para PDF
            using MemoryStream stream = new MemoryStream();
            PDFSimpleExport pdfExport = new PDFSimpleExport();
            report.Export(pdfExport, stream);
            return stream.ToArray();
        }
    }
}
