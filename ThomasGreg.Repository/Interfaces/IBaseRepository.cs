using System.Linq.Expressions;

namespace ThomasGreg.Repository.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        void SetDbContext<TContext>(TContext context);
        T Obter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        T ObterPrimeiro(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        T ObterUltimo(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Listar(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes);
        Task<T> AdicionarAsync(T obj);
        Task<T> EditarAsync(T obj);
        void Adicionar(T obj);
        void Editar(T pObj);
    }
}
