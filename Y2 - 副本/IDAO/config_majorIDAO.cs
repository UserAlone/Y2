using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface config_majorIDAO
    {
        List<T> config_majorSelect<T>() where T : class;
        List<T> config_majorIDSelect<T>(Expression<Func<T, bool>> where) where T : class;
        List<T> config_majorSelectID<T>(Expression<Func<T, bool>> where) where T : class;
        int config_majorInsert<T>(T t) where T : class;
        int config_majorDelete<T>(T t) where T : class;
    }
}
