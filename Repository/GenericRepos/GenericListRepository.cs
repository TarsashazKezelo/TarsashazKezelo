using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    public abstract class GenericListRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected List<TEntity> list;
        public GenericListRepository(params TEntity[] entities)
        {
            list = new List<TEntity>();
            list.AddRange(entities);
        }
        public void Delete(TEntity entityToDelete)
        {
            list.Remove(entityToDelete);
        }
        public void Delete(int id)
        {
            TEntity entityToDelete = GetById(id);
            if (entityToDelete == null)
            {
                throw new ArgumentException("No Data");
            }
            Delete(entityToDelete);
        }
        public void Dispose()
        {
            list.Clear();
            list = null;
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }
        public IQueryable<TEntity> GetAll()
        {
            return list.AsQueryable();
        }
        abstract public TEntity GetById(int id);
        public void Insert(TEntity newEntity)
        {
            list.Add(newEntity);
        }
    }
}
