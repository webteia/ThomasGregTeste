using ThomasGreg.Repository.Models;

namespace ThomasGreg.Repository.Interfaces
{
    public interface ILogradouroRepository : IBaseRepository<Logradouro>
    {
        Task<Logradouro> InserirComProcedure(Logradouro logradouro);
    }
}
