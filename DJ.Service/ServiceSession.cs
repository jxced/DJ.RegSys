using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJ.Service
{
    /// <summary>
    /// 数据仓储，作用：
    /// 1.调用EF容器 批量 执行 sql语句
    /// 2.方便通过 子接口属性直接 获取 对应数据表的操作接口对象
    /// </summary>
    public partial class ServiceSession : IService.IServiceSession
    {
        
        /// <summary>
        /// 统一保存线程内的ef crud操作
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return -1; //EFFactory.GetEFContext().SaveChanges();
        }
    }
}
