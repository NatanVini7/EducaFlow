using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFlow.Models
{
    public class Contato
    {
        [Key]
        public int IdContato { get; set; }
        public string? TelefoneContato { get; set; }
        public string? EmailContato { get; set; }
    }
}
