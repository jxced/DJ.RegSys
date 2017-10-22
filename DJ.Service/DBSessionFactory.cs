using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DJ.Service
{
   public class DBSessionFactory
    {
       public static IRepository.IDBSession GetDBSession()
        {
            var db= CallContext.GetData("DBSession") as IRepository.IDBSession;
            if (db==null)
            {
                db = DJ.Utility.DI.GetObject<IRepository.IDBSession>("DBSession");
                CallContext.SetData("DBSession", db);
            }
            return db;
        }
    }
}
