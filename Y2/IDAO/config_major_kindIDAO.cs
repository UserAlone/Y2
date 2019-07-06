using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface config_major_kindIDAO
    {
        List<T> config_major_kindSelect<T>() where T : class;
        List<T> config_major_kindSelectID<T>(Expression<Func<T, bool>> where) where T : class;
        int config_major_kindInsert<T>(T t) where T : class;
        int config_major_kindDelete<T>(T t) where T : class;
    }
}
