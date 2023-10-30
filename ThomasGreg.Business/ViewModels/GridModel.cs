using System.ComponentModel.DataAnnotations.Schema;

namespace ThomasGreg.Business.ViewModels
{
    public class GridModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string? Desc { get; set; }
        [NotMapped]
        public string? Data { get; set; }
    }

    public class GridModelList
    {
        [NotMapped]
        public List<GridModel>? GridData { get; set; }
    }
}
