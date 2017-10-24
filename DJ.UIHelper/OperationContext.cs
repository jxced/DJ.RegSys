using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DJ.UIHelper
{
    /// <summary>
    /// UI层操作上下文，封装业务层常用方法和属性供UI使用；
    /// </summary>
    public class OperationContext
    {
        private IService.IServiceSession _serviceSession;
        /// <summary>
        /// 从当前线程获取当前操作上下文对象，没有则新建；
        /// </summary>
        public static OperationContext Current
        {
            get
            {
                var context = CallContext.GetData(typeof(OperationContext).FullName) as OperationContext;
                if (context == null)
                {
                    context = new OperationContext();
                    CallContext.SetData(typeof(OperationContext).FullName, context);
                }
                return context;
            }
        }

        /// <summary>
        /// 获取业务层仓储
        /// </summary>
        public IService.IServiceSession ServiceSession {
            get {
                    if (_serviceSession == null)
                    {
                        _serviceSession = Utility.DI.GetObject<IService.IServiceSession>("ServiceSession");
                    }
                    return _serviceSession;
            }
        }
    }
}
