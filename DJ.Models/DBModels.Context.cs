﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RegSysEntities : DbContext
    {
        public RegSysEntities()
            : base("name=RegSysEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClassInfo> ClassInfo { get; set; }
        public virtual DbSet<CourseType> CourseType { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<StudentInfo> StudentInfo { get; set; }
        public virtual DbSet<Students_Subjects> Students_Subjects { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<UserCategory> UserCategory { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Subject_Cuorse> Subject_Cuorse { get; set; }
        public virtual DbSet<Teacher_Subject> Teacher_Subject { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfo { get; set; }
    }
}
