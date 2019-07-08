using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface userIDAO
    {
        List<T> userSelect<T>() where T : class;
        List<T> SelectWhere<T>(Expression<Func<T, bool>> where) where T : class;
    }
}
