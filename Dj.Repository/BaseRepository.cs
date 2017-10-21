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
using System.Reflection;

namespace DJ.Repository
{
    /// <summary>
    /// 数据仓储基类，实现数据仓储父接口
    /// </summary>
    /// <typeparam name="TEntity">实体类 类型参数-对应 要操作的数据表</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        DbContext db = EFFactory.GetEFContext();
        DbSet<TEntity> _dbset;
        public DbSet<TEntity> DbSet { get=>_dbset;}
        public BaseRepository()
        {
            _dbset = db.Set<TEntity>();
        }

        /// <summary>
        /// 新增Tentity 类型的实体
        /// </summary>
        /// <param name="entity">要新增的对象</param>
        /// <returns></returns>
        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        /// <summary>
        /// 删除传入的TEntity类型对象
        /// </summary>
        /// <param name="entity">要删除的对象</param>
        /// <returns></returns>
        public void Remove(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        /// <summary>
        /// 根据表达式pre条件更新
        /// </summary>
        /// <param name="expression">表达式条件</param>
        /// <returns></returns>
        public void Remove(Expression<Func<TEntity, bool>> expression)
        {
            var list= _dbset.Where(expression);
            foreach (var item in list)
            {
                _dbset.Remove(item);
            }
        }

        /// <summary>
        /// 根据传入的实体entity,修改数据
        /// </summary>
        /// <param name="entity">传入的实体entity</param>
        /// <param name="propertes">要修改的属性</param>
        public void Update(TEntity entity,params string[] propertes)
        {
            DbEntityEntry<TEntity> dbEntityEntry = db.Entry(entity);
            dbEntityEntry.State = EntityState.Unchanged;
            foreach (var item in propertes)
            {
                dbEntityEntry.Property(item).IsModified = true;
            }
        }

        /// <summary>
        /// 根据传入的表达式、属性名和属性值，修改数据
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <param name="properties">传入的属性名</param>
        /// <param name="values">传入的属性值</param>
        public void Update(Expression<Func<TEntity, bool>>expression, string[] properties, object[] values)
        {
            var list = _dbset.Where(expression);//根据表达式条件查询出数据集合；
            Type type = typeof(TEntity);//获得类的类型？
            foreach (var item in list)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo pro = type.GetProperty(properties[i]);
                    pro.SetValue(item, values[i]);
                }
            }
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
           return  _dbset.Where(expression);
        }
    }
}
