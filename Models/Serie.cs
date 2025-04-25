using System.ComponentModel.DataAnnotations;

namespace EducaFlow.Models
{
    public class Serie
    {
        [Key]
        public int IdSerie { get; set; }
        public int CodSerie { get; set; }
        [Required(ErrorMessage = "Curso é obrigatório")]
        public Curso? Curso { get; set; }
        [Required(ErrorMessage = "Nome da série é obrigatório")]
        public string? NomeSerie { get; set; }
        public int EtapaCurso { get; set; }
        [Required(ErrorMessage = "Regra de Avaliação é obrigatório")]
        public RegraAvaliacao RegraAvaliacao { get; set; }
        [Required(ErrorMessage = "Concluinte é obrigatório")]
        public bool Concluinte { get; set; }
        public float CargaHoraria { get; set; }
        public int DiasLetivos { get; set; }
        public int IdCurso { get; set; }
    }

    public enum RegraAvaliacao
    {
        Qualitativa = 0,
        Quantitativa = 1
    }
}
