﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.Caching;
using DJ.Utility;
using DJ.Models.TemplateModels;

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
        public DJ.Models.UserInfo SessionUserInfo
        {
            get
            {
                return HttpContext.Current.Session[UtilityStr.USER_SESSION_KEY] as DJ.Models.UserInfo;
            }
            set
            {
                HttpContext.Current.Session[UtilityStr.USER_SESSION_KEY] = value;
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
        public string Cookie
        {
            get
            {
                var cookie = Request.Cookies[UtilityStr.USER_COOKIE_KEY].Value;
                return cookie;
            }
            set
            {
                var cookie = new HttpCookie(UtilityStr.USER_COOKIE_KEY);
                cookie.Value = value;
                cookie.Expires = DateTime.Now.AddDays(7);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region 定义的json格式消息集合
        /// <summary>
        /// 返回操作成功的json格式数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="backUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult MsgOK(string msgOk = "操作成功", string backUrl = "", object data = null)
        {
            return AjaxMsg(new AjaxMsg() { States = MsgState.OK, Msg = msgOk, BackUrl = backUrl, Data = data });
        }
        /// <summary>
        /// 返回操作失败的json格式数据
        /// </summary>
        /// <param name="msgFail"></param>
        /// <param name="backUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult MsgFail(string msgFail = "操作失败", string backUrl = "", object data = null)
        {
            return AjaxMsg(new AjaxMsg() { States = MsgState.OK, Msg = msgFail, BackUrl = backUrl, Data = data });
        }
        public JsonResult MsgNoLogin(string msgNoLogin = "未登录", string backUrl = "", object data = null)
        {
            return AjaxMsg(new AjaxMsg() { States = MsgState.OK, Msg = msgNoLogin, BackUrl = backUrl, Data = data });
        }
        public JsonResult MsgNoPermission(string  msgNoPermission = "没有访问此操作的权限", string backUrl = "", object data = null)
        {
            return AjaxMsg(new AjaxMsg() { States = MsgState.OK, Msg = msgNoPermission, BackUrl = backUrl, Data = data });
        }
        public JsonResult MsgErr(string msgErr = "操作异常", string backUrl = "", object data = null)
        {
            return AjaxMsg(new AjaxMsg() { States = MsgState.OK, Msg = msgErr, BackUrl = backUrl, Data = data });
        }
        /// <summary>
        /// 返回ajax请求的json数据
        /// </summary>
        /// <param name="ajaxMsg">传入json消息对象</param>
        /// <returns></returns>
        public JsonResult AjaxMsg(AjaxMsg ajaxMsg)
        {
            return new JsonResult()
            {
                Data = ajaxMsg,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        #endregion
        public ContentResult JsMsg(string msg="",string backUrl="")
        {
            StringBuilder jStr = new StringBuilder();
            jStr.Append("<script> alert(\"").Append(msg)
                .Append("\"); if (window.top != window) { window.top.location =\"")
                .Append(backUrl).Append("\" }else { window.location=\"")
                .Append(backUrl).Append("\";} </script>");
            return new ContentResult() {
                Content = jStr.ToString(),
                ContentEncoding = Encoding.UTF8
            };
        }
    }
}
