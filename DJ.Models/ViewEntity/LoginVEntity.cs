using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJ.Models.ViewEntity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class LoginVEntity
    {
        
        [Required(ErrorMessage ="用户名不能为空")]
        public string Email { get; set; }
        [Required(ErrorMessage ="密码不能为空")]
        [MinLength(8,ErrorMessage ="密码长度至少8位")]
        public string Pwd { get; set; }
        public bool IsKeep { get; set; }
    }
}