using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using System.Linq.Expressions;

namespace BAL
{
    public class engage_major_releaseDao : BaseDao, engage_major_releaseIDAO
    {
        public int engage_major_releaseDelete<T>(T t) where T : class
        {
            return Delete(t);
        }

        public List<T> engage_major_releaseFenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class
        {
            return FenYe<T, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int engage_major_releaseInsert<T>(T t) where T : class
        {
            return Add(t);
        }

        public int engage_major_releaseUpdate<T>(T t) where T : class
        {
            return Update(t);
        }

        public List<T> engage_major_releaseUpdateCha<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }
    }
}
