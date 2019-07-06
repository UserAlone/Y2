using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
   public interface RoleRigIBLL
    {
        //查询全部
        List<Role> Show<Role>() where Role : class;
        //查询单行
        List<Role> SelectWhere(Expression<Func<Role, bool>> where);
        //分页查询
       List<Role> FenYe(Expression<Func<Role, int>> order, Expression<Func<Role, bool>> where, out int rows, out int pages, int currentPage, int pageSize);
        //添加
        int Add<Role>(Role t) where Role : class;
        //修改
        int Update<Role>(Role t) where Role : class;
        //删除
        int Delete<Role>(Role t) where Role : class;
    }
}
