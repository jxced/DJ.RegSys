using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace DJ.Web.Filter
{
    public class AuthorizationAttribute:AuthorizeAttribute
    {
        DJ.UIHelper.OperationContext operationContext = new UIHelper.OperationContext();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsLogin())
            {

            }
            else
            {
                filterContext.Result = operationContext.JsMsg("未登陆，请重新登陆！","/index.html");
            }
            //base.OnAuthorization(filterContext);
            
        }
        private bool IsLogin()
        {
            if (operationContext.SessionUserInfo==null)
            {
                var userId = operationContext.Cookie.AsInt();
                if (userId>0)
                {
                    return false;
                }
                else
                {
                    var user= operationContext.ServiceSession.UserInfoBLL.Where(o => o.UserId == userId).SingleOrDefault();
                    if (user!=null)
                    {
                        operationContext.SessionUserInfo = user.ToPOCO();
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }
    }
}