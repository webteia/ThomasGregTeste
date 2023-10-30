using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThomasGreg.Business.ViewModels;

namespace ThomasGregTeste.Business.Models
{
    public class ClienteViewModel 
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        [Display(Name ="Nome do Cliente")]
        [StringLength(200, ErrorMessage = "O nome deve conter um total máximo de 200 caractéres")]
        [MinLength(8, ErrorMessage = "O nome deve conter um mínimo de 8 caractéres")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail do cliente é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do e-mail é inválido")]
        [Display(Name = "Email do Cliente")]
        [StringLength(50, ErrorMessage = "O nome deve conter um total máximo de 50 caractéres")]
        public string Email { get; set; }
        [Display(Name = "Você pode inserir uma imagem de logo")]
        public string? Logotipo { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }

        public List<LogradouroViewModel>? Logradouros { get; set; }

        [NotMapped]
        public FluentValidation.Results.ValidationResult? Validacoes { get; set; }
    }
}
