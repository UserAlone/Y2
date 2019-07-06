using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface engage_resumeIDAO
    {
        int engage_resumeInsert<T>(T t) where T : class;
        List<T> engage_resumeSelect<T>() where T : class;
        List<T> engage_resumeFenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class;
        List<T> engage_resumeUpdateCha<T>(Expression<Func<T, bool>> where) where T : class;
        int engage_resumeUpdate<T>(T t) where T : class;
        int engage_resumeDelete<T>(T t) where T : class;
        List<T> engage_resumeFenYe2<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class;
    }
}
