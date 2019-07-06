using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface UserIDAO
    {
        //查询单行
        List<T> SelectWhere<T>(Expression<Func<T, bool>> where) where T : class;
    }
}
