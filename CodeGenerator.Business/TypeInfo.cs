using CodeGenerator.Entity.POCOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Business
{
    public class TypeInfo
    {
        //添加类别
        public bool AddTypeInfo(string t_title)
        {
            using (CGDataBase db = new CGDataBase())
            {
                type t = new type()
                {
                    t_title = t_title
                };
                db.type.Add(t);
                return db.SaveChanges() > 0;
            }
        }

        public List<type> SelectAllInfo()
        {
            using (var db = new CGDataBase())
            {
                var list = db.type.Where(t => true).ToList();
                return list;
            }
        }
    }
}
