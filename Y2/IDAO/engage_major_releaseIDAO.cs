using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface engage_major_releaseIDAO
    {
        int engage_major_releaseInsert<T>(T t) where T : class;
        List<T> engage_major_releaseFenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class;
        List<T> engage_major_releaseUpdateCha<T>(Expression<Func<T, bool>> where) where T : class;
        int engage_major_releaseUpdate<T>(T t) where T : class;
        int engage_major_releaseDelete<T>(T t) where T : class;
    }
}
