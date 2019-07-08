using IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public class human_fileBAL:BaseDao, human_fileIDAO
    {
        public int human_fileDelete<T>(T t) where T : class
        {
            return Delete(t);
        }

        public int human_fileDelete2(string sql)
        {
            return AUD(sql);
        }

        public List<T> human_fileFenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class
        {
            return FenYe<T, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int human_fileInsert<T>(T t) where T : class
        {
            return Add(t);
        }

        public List<T> human_fileSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> human_fileSelectCha<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }

        public int human_fileUpdate<T>(T t) where T : class
        {
            return Update(t);
        }
    }
}
