using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJ.IRepository;
using DJ.Models;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace DJ.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        DbContext db = EFFactory.GetEFContext();
        DbSet<TEntity> _dbset;
        public DbSet<TEntity> DbSet { get=>_dbset;}
        public BaseRepository()
        {
            _dbset = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void Remove(Expression<Func<TEntity, bool>> pre)
        {
            var list= _dbset.Where(pre);
            foreach (var item in list)
            {
                _dbset.Remove(item);
            }
        }

        public void Update(TEntity entity)
        {
            DbEntityEntry;
        }
    }
}
