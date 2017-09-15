using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DJ.Repository
{
    public class EFFactory
    {
        /// <summary>
        /// 检查当前线程是否存在ef容器，存在则直接返回当前线程的ef容器，不存在则新建ef容器，使当前线程ef容器唯一。
        /// </summary>
        /// <returns>当前线程的ef容器</returns>
        public static DbContext GetEFContext()
        {
            DbContext db = CallContext.GetData("efContext") as DbContext;
            if (db==null)
            {
                db = new RegSysEntities();
                CallContext.SetData("efContext", db);
            }
            return db;
        }

        /// <summary>
        /// 使用特性指定当前线程ef容器唯一
        /// </summary>
        [ThreadStatic]
        static DbContext db = new RegSysEntities();
        public static DbContext GetContextT()
        {
            return db;
        }
    }
}
