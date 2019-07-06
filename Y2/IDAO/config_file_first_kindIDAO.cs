using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface config_file_first_kindIDAO
    {
        List<T> config_file_first_kindSelect<T>() where T : class;

        List<T> config_file_first_kindSelectID<T>(Expression<Func<T, bool>> where) where T : class;
    }
}
