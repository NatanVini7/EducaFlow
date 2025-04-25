using System.ComponentModel.DataAnnotations;

namespace EducaFlow.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public int CodCurso { get; set; }
        [Required(ErrorMessage= "Nome do Curso é obrigatório.")]
        public string? NomeCurso { get; set; }
        public string? SiglaCurso { get; set; }
        public int QtdEtapas { get; set; }
        public NiveisEnsino NiveisEnsino { get; set; }
    }

    public enum NiveisEnsino
    {
        Eja = 0,
        EducacaoProfissional = 1,
        EnsinoEspecial = 2, 
        Ead = 3,
        Noturno = 4,
        Presencial = 5
    }
}
