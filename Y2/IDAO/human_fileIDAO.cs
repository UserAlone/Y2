using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface human_fileIDAO
    {
        List<T> human_fileSelect<T>() where T:class;
        int human_fileInsert<T>(T t) where T:class;
        List<T> human_fileSelectCha<T>(Expression<Func<T, bool>> where) where T : class;
        int human_fileUpdate<T>(T t) where T : class;
        List<T> human_fileFenYe<T,K>(Expression<Func<T,K>> order, Expression<Func<T,bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class;
        int human_fileDelete<T>(T t) where T : class;
        int human_fileDelete2(string sql);


        //查询全部
        List<T> SelectAll<T>() where T : class;

        //条件查询
        List<T> SelectWhere<T>(Expression<Func<T, bool>> where) where T : class;
    }
}
