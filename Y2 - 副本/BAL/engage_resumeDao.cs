using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;

namespace BAL
{
    public class engage_resumeDao : BaseDao, engage_resumeIDAO
    {
        public int engage_resumeDelete<T>(T t) where T : class
        {
            return Delete(t);
        }

        public List<T> engage_resumeFenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class
        {
            return FenYe<T, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public List<T> engage_resumeFenYe2<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class
        {
            return FenYe<T, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int engage_resumeInsert<T>(T t) where T : class
        {
            return Add(t);
        }

        public List<T> engage_resumeSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public int engage_resumeUpdate<T>(T t) where T : class
        {
            return Update(t);
        }

        public List<T> engage_resumeUpdateCha<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }
    }
}
