using System.ComponentModel.DataAnnotations;

namespace EducaFlow.Models
{
    public class Escola
    {
        [Key]
        public int IdEscola { get; set; }
        [Required(ErrorMessage = "O Nome da Escola é obrigatório.")]
        public string? NomeEscola { get; set; }
        public string? NomeFantasia { get; set; }
        public string? NumeroInep { get; set; }
        [Required(ErrorMessage = "O CNPJ da escola é obrigatório.")]
        public string? CNPJ { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Site { get; set; }
        public string? TipoEscola { get; set; }
        public string? TipoEnsino { get; set; }
        public string? TipoVinculo { get; set; }
        public Contato? Contato { get; set; }
        public Endereco? Endereco { get; set; }
        public int IdEndereco { get; set; }
        public int IdContato { get; set; }
    }
}
