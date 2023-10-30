using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ThomasGreg.Repository.Models
{
    [Index(propertyNames: nameof(Email), IsUnique = true)]
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string? Logotipo { get; set; }

        public virtual List<Logradouro> Logradouros { get; set; }
    }
}
