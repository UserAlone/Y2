using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface config_file_third_kindIDAO
    {
        List<T> config_file_third_kindISelect<T>() where T : class;
        List<T> config_file_third_kindIDSelect<T>(Expression<Func<T, bool>> where) where T : class;
        List<T> config_file_third_kindSelectID<T>(Expression<Func<T, bool>> where) where T : class;
    }
}
