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
        /// 根据表达式pre条件更新
        /// </summary>
        /// <param name="pre">表达式条件</param>
        /// <returns></returns>
        void Remove(Expression<Func<TEntity, bool>> pre);

        /// <summary>
        /// 修改传入的TEntity类型对象
        /// </summary>
        /// <param name="entity">要修改的对象</param>
        void Update(TEntity entity);
    }
}
