using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJ.IRepository
{
    /// <summary>
    /// 数据层父接口
    /// </summary>
    /// <typeparam name="TEntity">实体类，对应要操作的表</typeparam>
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        /// <summary>
        /// 新增Tentity 类型的实体
        /// </summary>
        /// <param name="entity">要新增的对象</param>
        /// <returns></returns>
        void Add(TEntity entity);

        /// <summary>
        /// 删除传入的TEntity类型对象
        /// </summary>
        /// <param name="entity">要删除的对象</param>
        /// <returns></returns>
        void Remove(TEntity entity);

        /// <summary>
        /// 根据表达式expression条件更新
        /// </summary>
        /// <param name="expression">表达式条件</param>
        /// <returns></returns>
        void Remove(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 根据传入的实体和属性名，修改数据
        /// </summary>
        /// <param name="entity">传入的实体</param>
        /// <param name="properties">传入要修改的属性名</param>
        void Update(TEntity entity,params string[] properties);

        /// <summary>
        /// 根据传入的表达式、属性名和属性值，修改数据
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <param name="properties">传入的属性名</param>
        /// <param name="values">传入的属性值</param>
        void Update(Expression<Func<TEntity, bool>> expression, string[] properties, object[] values);

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
    }
}
