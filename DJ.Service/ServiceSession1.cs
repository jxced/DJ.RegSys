﻿//------------------------------------------------------------------------------
// <auto-generated>
// 数据仓储，作用：
// 1.调用EF容器 批量 执行 sql语句
// 2.方便通过 子接口属性直接 获取 对应数据表的操作接口对象
// </auto-generated>
//------------------------------------------------------------------------------

namespace DJ.Service
{
    using System;
    public partial class ServiceSession:DJ.IService.IServiceSession
    {
    	DJ.IService.IClassInfoBLL  _ClassInfoBLL;
        public DJ.IService.IClassInfoBLL  ClassInfoBLL
    	{
    		get
    		{
    			if(_ClassInfoBLL==null)
    			{
    				_ClassInfoBLL=new ClassInfoBLL();
    			}
    			return _ClassInfoBLL;
    		}
    	}
    	DJ.IService.ICourseTypeBLL  _CourseTypeBLL;
        public DJ.IService.ICourseTypeBLL  CourseTypeBLL
    	{
    		get
    		{
    			if(_CourseTypeBLL==null)
    			{
    				_CourseTypeBLL=new CourseTypeBLL();
    			}
    			return _CourseTypeBLL;
    		}
    	}
    	DJ.IService.ISpecialtyBLL  _SpecialtyBLL;
        public DJ.IService.ISpecialtyBLL  SpecialtyBLL
    	{
    		get
    		{
    			if(_SpecialtyBLL==null)
    			{
    				_SpecialtyBLL=new SpecialtyBLL();
    			}
    			return _SpecialtyBLL;
    		}
    	}
    	DJ.IService.IStudentInfoBLL  _StudentInfoBLL;
        public DJ.IService.IStudentInfoBLL  StudentInfoBLL
    	{
    		get
    		{
    			if(_StudentInfoBLL==null)
    			{
    				_StudentInfoBLL=new StudentInfoBLL();
    			}
    			return _StudentInfoBLL;
    		}
    	}
    	DJ.IService.IStudents_SubjectsBLL  _Students_SubjectsBLL;
        public DJ.IService.IStudents_SubjectsBLL  Students_SubjectsBLL
    	{
    		get
    		{
    			if(_Students_SubjectsBLL==null)
    			{
    				_Students_SubjectsBLL=new Students_SubjectsBLL();
    			}
    			return _Students_SubjectsBLL;
    		}
    	}
    	DJ.IService.ISubjectsBLL  _SubjectsBLL;
        public DJ.IService.ISubjectsBLL  SubjectsBLL
    	{
    		get
    		{
    			if(_SubjectsBLL==null)
    			{
    				_SubjectsBLL=new SubjectsBLL();
    			}
    			return _SubjectsBLL;
    		}
    	}
    	DJ.IService.IUserCategoryBLL  _UserCategoryBLL;
        public DJ.IService.IUserCategoryBLL  UserCategoryBLL
    	{
    		get
    		{
    			if(_UserCategoryBLL==null)
    			{
    				_UserCategoryBLL=new UserCategoryBLL();
    			}
    			return _UserCategoryBLL;
    		}
    	}
    	DJ.IService.IUserInfoBLL  _UserInfoBLL;
        public DJ.IService.IUserInfoBLL  UserInfoBLL
    	{
    		get
    		{
    			if(_UserInfoBLL==null)
    			{
    				_UserInfoBLL=new UserInfoBLL();
    			}
    			return _UserInfoBLL;
    		}
    	}
    	DJ.IService.ISubject_CuorseBLL  _Subject_CuorseBLL;
        public DJ.IService.ISubject_CuorseBLL  Subject_CuorseBLL
    	{
    		get
    		{
    			if(_Subject_CuorseBLL==null)
    			{
    				_Subject_CuorseBLL=new Subject_CuorseBLL();
    			}
    			return _Subject_CuorseBLL;
    		}
    	}
    	DJ.IService.ITeacher_SubjectBLL  _Teacher_SubjectBLL;
        public DJ.IService.ITeacher_SubjectBLL  Teacher_SubjectBLL
    	{
    		get
    		{
    			if(_Teacher_SubjectBLL==null)
    			{
    				_Teacher_SubjectBLL=new Teacher_SubjectBLL();
    			}
    			return _Teacher_SubjectBLL;
    		}
    	}
    	DJ.IService.ITeacherInfoBLL  _TeacherInfoBLL;
        public DJ.IService.ITeacherInfoBLL  TeacherInfoBLL
    	{
    		get
    		{
    			if(_TeacherInfoBLL==null)
    			{
    				_TeacherInfoBLL=new TeacherInfoBLL();
    			}
    			return _TeacherInfoBLL;
    		}
    	}
    }
}