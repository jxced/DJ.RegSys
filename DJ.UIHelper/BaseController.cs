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
    }
}
