using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface engage_interviewIDAO
    {
        List<T> engage_interviewSelect<T>() where T : class;
        List<T> engage_interviewSelectID<T>(Expression<Func<T, bool>> where) where T : class;
        int engage_interviewInsert<T>(T t) where T : class;
        int engage_interviewUpdate<T>(T t) where T : class;
        List<T> engage_interviewFenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class;
        int engage_interviewDelete(string sql);
    }
}
