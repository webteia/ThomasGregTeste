using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThomasGreg.Repository.Models
{
    public class Logradouro : BaseEntity
    {
        public string Endereco { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
    }
}
