using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDAO;

namespace BAL
{
    public class config_majorDao : BaseDao, config_majorIDAO
    {
        public int config_majorDelete<T>(T t) where T : class
        {
            return Delete(t);
        }

        public List<T> config_majorIDSelect<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }

        public int config_majorInsert<T>(T t) where T : class
        {
            return Add(t);
        }

        public List<T> config_majorSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> config_majorSelectID<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }
    }
}
