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
    public class config_file_first_kindDao : BaseDao, config_file_first_kindIDAO
    {
        public List<T> config_file_first_kindSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> config_file_first_kindSelectID<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }
    }
}
