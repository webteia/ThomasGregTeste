using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThomasGregTeste.Business.Models
{
    public class LogradouroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="É necessário fornecer o endereço")]
        [Display(Name ="Endereço")]
        public string Endereco { get; set; }

        public int ClienteId { get; set; }
        public ClienteViewModel? Cliente { get; set; }
        [NotMapped]
        public FluentValidation.Results.ValidationResult? Validacoes { get; set; }
    }
}
