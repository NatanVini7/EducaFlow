using System.ComponentModel.DataAnnotations;

namespace EducaFlow.Models
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }
        [Required(ErrorMessage = "O Nome do Aluno é obrigatório.")]
        public string? NomeAluno { get; set; }
        [StringLength(14, ErrorMessage = "O CPF deve ter 14 dígitos.")]
        [Required(ErrorMessage = "O CPF do Aluno é obrigatório.")]
        public string? CPF { get; set; }
        public string? NomeSocial { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? UFEmissor { get; set; }
        public string? RG { get; set; }
        public string? NumeroNisPisPasep { get; set; }
        public string? NumeroSus { get; set; }
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? NumeroInep { get; set; }
        public string? NumeroRa { get; set; }
        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateOnly DatadeNascimento { get; set; }
        public DateOnly DatadeEmissao { get; set; }
        public AlunoStatus Status { get; set; }
        [Required(ErrorMessage = "Sexo é obrigatório.")]
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Etnia Etnia { get; set; }
        public Transporte Transporte { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
        public bool Alfabetizado { get; set; }
        public bool Deficiencia { get; set; }
        public string? DeficienciaEspecificar { get; set; }
        public bool Emancipado { get; set; }
        public Contato Contato { get; set; } = new Contato();
        public Endereco Endereco { get; set; } = new Endereco();
        public int IdContato { get; set; }
        public int IdEndereco { get; set; }
    }

    public enum AlunoStatus
    {
        Ativo = 0,
        Inativo = 1,
        Transferido = 2,
        Falecido = 3
    }
    public enum Sexo
    {
        Masculino = 0,
        Feminino = 1,
        Outro = 2
    }
    public enum EstadoCivil
    {
        Solteiro = 0,
        Casado = 1,
        Divorciado = 2,
        Viúvo = 3,
        Outro = 4
    }
    public enum Etnia
    {
        Branca = 0,
        Preta = 1,
        Parda = 2,
        Amarela = 3,
        Indigena = 4,
        Outro = 5
    }
    public enum Transporte
    {
        NaoUtiliza = 0,
        Municipal = 1,
        Estadual = 2
    }
    public enum TipoTransporte
    {
        RodoviarioVanKombi = 0,
        RodoviarioOnibus = 1,
        RodoviarioMicro = 2,
        RodoviarioBicicleta = 3,
        RodoviarioTracaoAnimal = 4,
        RodoviarioOutro = 5,
        Aquaviario = 6
    }
}
