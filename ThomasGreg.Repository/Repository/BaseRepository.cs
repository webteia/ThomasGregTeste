using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ThomasGreg.Repository.Interfaces;
using ThomasGreg.Repository.Models;
using ThomasGregTeste.Data;

namespace ThomasGreg.Repository.Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        protected ThomasGregDbContext Db = new ThomasGregDbContext();

        public BaseRepository()
        {           
        }

        public void Adicionar(T objeto)
        {
            objeto.DataCadastro = DateTime.Now;
            Db.Set<T>().Add(objeto);
            Db.SaveChanges();
        }

        public async Task<T> AdicionarAsync(T objeto)
        {
            objeto.DataCadastro = DateTime.Now;
            await Db.Set<T>().AddAsync(objeto);
            await Db.SaveChangesAsync();
            return objeto;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Editar(T objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            Db.Set<T>().Update(objeto);
            Db.SaveChanges();
        }

        public async Task<T> EditarAsync(T objeto)
        {
            objeto.DataAlteracao = DateTime.Now;
            var entry = Db.Entry(objeto);
            entry.State = EntityState.Modified;
            Db.Set<T>().Update(objeto);
            await Db.SaveChangesAsync();
            return objeto;
        }

        public IEnumerable<T> Listar(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Db.Set<T>().AsNoTracking();

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }

            if (where == null)
            {
                return query;
            }

            return query.Where(where);
        }

        public T Obter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Db.Set<T>().AsNoTracking();

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }

            T response = query.FirstOrDefault(where);

            return response;
        }

        public T ObterPrimeiro(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Db.Set<T>().AsNoTracking();

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }

            T response = query.FirstOrDefault(where);

            return response;
        }

        public T ObterUltimo(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Db.Set<T>().AsNoTracking();

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }

            T response = query.LastOrDefault(where);

            return response;
        }

        public void SetDbContext<TContext>(TContext context)
        {
            Db = context as ThomasGregDbContext;
        }

    }
}
