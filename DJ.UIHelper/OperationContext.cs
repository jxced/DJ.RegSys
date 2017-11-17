using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.Caching;

namespace DJ.UIHelper
{
    /// <summary>
    /// UI层操作上下文，封装业务层常用方法和属性供UI使用；
    /// </summary>
    public class OperationContext
    {
        //定义用户session键的常量
        //public const string USER_SESSION_KEY="uInfo";
        //定义用户权限session键的常量
        //public const string USER_PER_SESSION_KEY = "uPer";
        //定义用户cookie session键的常量
        //public const string USER_COOKIE_KEY = "ucookie";
        private IService.IServiceSession _serviceSession;
        #region 封装当前线程的UI层操作上下文
        /// <summary>
        /// 封装当前线程的UI操作上下文：从当前线程获取当前操作上下文对象，没有则新建；
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
        #endregion

        #region 封装当前线程的业务层仓储
        /// <summary>
        /// 获取业务层仓储
        /// </summary>
        public IService.IServiceSession ServiceSession
        {
            get
            {
                if (_serviceSession == null)
                {
                    _serviceSession = Utility.DI.GetObject<IService.IServiceSession>("ServiceSession");
                }
                return _serviceSession;
            }
        }
        #endregion

        #region 封装当前线程http信息的上下文和上下文的属性
        public HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }
        public HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
        public HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        public HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }
        public HttpServerUtility Server
        {
            get
            {
                return HttpContext.Current.Server;
            }
        }
        public Cache Cache
        {
            get
            {
                return HttpContext.Current.Cache;
            }
        }
        #endregion
    }
}
