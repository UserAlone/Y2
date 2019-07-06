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
    public class config_file_third_kindDao : BaseDao, config_file_third_kindIDAO
    {
        public List<T> config_file_third_kindIDSelect<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }

        public List<T> config_file_third_kindISelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> config_file_third_kindSelectID<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }
    }
}
