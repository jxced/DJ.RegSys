//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DJ.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students_SubjectsBLL:BaseService<Models.Students_Subjects>,IService.IStudents_SubjectsBLL
    {
    	IRepository.IStudents_SubjectsDAL dal =null; 
    	public override void SetRepository(out IRepository.IBaseRepository<Models.Students_Subjects> baseRepository)
            {
                dal= base.DBSession.Students_SubjectsDAL;
                baseRepository = dal as IRepository.IBaseRepository<Models.Students_Subjects>;
            }
    }
}
