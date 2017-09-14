//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DJ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserInfo()
        {
            this.ClassInfo = new HashSet<ClassInfo>();
        }
    
        public int UserId { get; set; }
        public int UserCategoryId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public System.DateTime AddTime { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public Nullable<sbyte> IsDel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassInfo> ClassInfo { get; set; }
        public virtual UserCategory UserCategory { get; set; }
    }
}
