using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    public abstract class GenericSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected SqlDriver driver;
        protected string tableName;
        protected string idName;
        public GenericSQLRepository(string connStr, string newTable, string newId)
        {
            driver = new SqlDriver(connStr);
            tableName = newTable;
            idName = newId;
        }
        public abstract void Insert(TEntity newEntity);
        public abstract int GetIdValue(TEntity input);
        public abstract TEntity RowToEntity(Dictionary<string, object> row);
        public void Delete(int id)
        {
            string sql = string.Format("delete form {0} where {1} = @idVal", tableName, idName);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("idVal", id.ToString());
            driver.ExecOther(sql, dict);
        }
        public void Delete(TEntity entityToDelete)
        {
            Delete(GetIdValue(entityToDelete));
        }
        public TEntity GetById(int id)
        {
            string sql = string.Format("select * from {0} where {1} = @idVal", tableName, idName);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var result = driver.ExecSelect(sql, dict).SingleOrDefault();
            return result == null ? null : RowToEntity(result);
        }
        public IQueryable<TEntity> GetAll()
        {
            string sql = string.Format("select * from {0}", tableName);
            return driver.ExecSelect(sql).Select(x => RowToEntity(x)).AsQueryable();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
