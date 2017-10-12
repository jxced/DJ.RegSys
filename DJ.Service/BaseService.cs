using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJ.IRepository;
using DJ.Models;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace DJ.Service
{
    public abstract class BaseService<TEntity> : IService.IBaseService<TEntity> where TEntity : class
    {
        IBaseRepository<TEntity> baseRepository = null;

        public BaseService()
        {
            SetRepository();
        }
        public abstract void SetRepository();
        
        /// <summary>
        /// 新增Tentity 类型的实体
        /// </summary>
        /// <param name="entity">要新增的对象</param>
        /// <returns></returns>
        public void Add(TEntity entity)
        {
            try
            {
                baseRepository.Add(entity);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            
        }

        /// <summary>
        /// 删除传入的TEntity类型对象
        /// </summary>
        /// <param name="entity">要删除的对象</param>
        /// <returns></returns>
        public void Remove(TEntity entity)
        {
            try
            {
                baseRepository.Remove(entity);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            
        }

        /// <summary>
        /// 根据表达式pre条件更新
        /// </summary>
        /// <param name="expression">表达式条件</param>
        /// <returns></returns>
        public void Remove(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                baseRepository.Remove(expression);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// 根据传入的实体entity,修改数据
        /// </summary>
        /// <param name="entity">传入的实体entity</param>
        /// <param name="propertes">要修改的属性</param>
        public void Update(TEntity entity,params string[] propertes)
        {
          
        }

        /// <summary>
        /// 根据传入的表达式、属性名和属性值，修改数据
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <param name="properties">传入的属性名</param>
        /// <param name="values">传入的属性值</param>
        public void Update(Expression<Func<TEntity, bool>>expression, string[] properties, object[] values)
        {
            
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return new List<TEntity>();
        }
    }
}
