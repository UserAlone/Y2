using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace IBLL
{
    public interface RoleUsIBLL
    {
        //查询全部
        List<RoleUs> Show<RoleUs>() where RoleUs : class;
        //查询单行
        List<Users> SelectWhere<Users>(Expression<Func<Users, bool>> where) where Users : class;
        //分页查询
        List<RoleUs> FenYe(Expression<Func<RoleUs, int>> order, Expression<Func<RoleUs, bool>> where, out int rows, out int pages, int currentPage, int pageSize);
        //添加
        int Add<Users>(Users t) where Users : class;
        //修改
        int Update<Users>(Users t) where Users : class;
        //删除
        int Delete<Users>(Users t) where Users : class;
    }
}
