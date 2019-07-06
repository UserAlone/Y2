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
    public class engage_interviewDao : BaseDao, engage_interviewIDAO
    {
        public int engage_interviewDelete(string sql)
        {
            return AUD(sql);
        }

        public List<T> engage_interviewFenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class
        {
            return FenYe<T, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int engage_interviewInsert<T>(T t) where T : class
        {
            return Add(t);
        }

        public List<T> engage_interviewSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> engage_interviewSelectID<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }

        public int engage_interviewUpdate<T>(T t) where T : class
        {
            return Update(t);
        }
    }
}
