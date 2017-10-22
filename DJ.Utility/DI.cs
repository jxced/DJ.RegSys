using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace DJ.Utility
{
    public class DI
    {
        [ThreadStatic]//线程唯一特性
       private static  IApplicationContext context = ContextRegistry.GetContext();//注册上下文
        /// <summary>
        /// 创建具体类型对象
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="objectName">要获取对象的名称</param>
        /// <returns></returns>
        public static T GetObject<T>(string objectName) where T:class//where 指定只能是引用类型
        {
            return context.GetObject<T>(objectName);
        }
    }
}
