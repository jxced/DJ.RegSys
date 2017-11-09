using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJ.Models.TemplateModels
{
    public class AjaxMsg
    {
        public MsgState States { get; set; }
        public string Msg { get; set; }
        public string BackUrl { get; set; }
        public object Data { get; set; }
    }

    public enum MsgState
    {
        OK=1,
        Fail=2,
        NoLogin=3,
        NoPermission=4,
        Error=5,
        Other=6
    }
}
