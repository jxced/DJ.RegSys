using System;
using System.Collections.Generic;
using System.Linq;
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
        int Add(TEntity entity);
        int Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
