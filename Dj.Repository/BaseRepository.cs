using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJ.IRepository;
using DJ.Models;
using System.Data.Entity;

namespace DJ.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        DbContext db = new RegSysEntities();
        DbSet<TEntity> _dbset;
        public BaseRepository()
        {
            _dbset = db.Set<TEntity>();
        }
        public int Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
