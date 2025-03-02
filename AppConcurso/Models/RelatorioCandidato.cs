using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    public class RelatorioCandidato
    {
        public string NomeCandidato { get; set; }
        public string CpfCandidato { get; set; }
        public string EditalConcurso { get; set; }
        public DateTime? DataConcurso { get; set; }
    }
}


