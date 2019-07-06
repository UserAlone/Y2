using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IDAO
{
    public interface RoleUsIDAO
    {
        //查询全部
       List<T> SelectAll<T>() where T : class;
        //查询单行
       List<T> SelectWhere<T>(Expression<Func<T, bool>> where) where T : class;
        //分页查询
        List<T> FenYe<T, K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows, out int pages, int currentPage, int pageSize) where T : class;
        //添加
        int Add<T>(T t) where T : class;
        //修改
        int Update<T>(T t) where T : class;
        //删除
        int Delete<T>(T t) where T : class;
    }      
}
