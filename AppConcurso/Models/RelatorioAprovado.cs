using System.ComponentModel.DataAnnotations.Schema;

namespace AppConcurso.Models
{
    public class RelatorioAprovado
    {
        public string NomeCandidato { get; set; }
        public double Media { get; set; }
        public int Posicao { get; set; }
        public string EditalConcurso { get; set; }
    }

}
