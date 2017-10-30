using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DJ.Models.TemplateModels;

namespace DJ.UIHelper
{
    public class BaseController:Controller
    {
        /// <summary>
        /// 当前线程操作上下文
        /// </summary>
        public OperationContext CurrentContext
        {
           get
            {
                return OperationContext.Current;
            }
        }
        
        /// <summary>
        /// 返回操作成功的json格式数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="backUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult MsgOK(string msgOk="操作成功",string backUrl="",object data=null)
        {
            return AjaxMsg(new AjaxMsg() {States=MsgState.OK,Msg=msgOk,BackUrl=backUrl,Data=data });
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
        public JsonResult MsgNoPermission(string msgNoPermission = "没有访问此操作的权限", string backUrl = "", object data = null)
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
                Data = ajaxMsg
            };
        }
    }
}
