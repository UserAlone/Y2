using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;

namespace BAL
{
    public class config_major_kindDao:BaseDao,config_major_kindIDAO
    {
        public int config_major_kindDelete<T>(T t) where T : class
        {
            return Delete(t);
        }

        public int config_major_kindInsert<T>(T t) where T : class
        {
            return Add(t);
        }

        public List<T> config_major_kindSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> config_major_kindSelectID<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }
    }
}
