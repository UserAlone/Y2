using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using locContaniner;
using Model;

namespace BLL
{
    public class RoleRigBLL : RoleRigIBLL
    {
        RoleRigIDAO ri = IocCreate.CreateProductTypeDao<RoleRigIDAO>("JiaoOne", "RoleRigBAL");
        public int Add<Role>(Role t) where Role : class
        {
            return ri.Add<Role>(t);
        }

        public int Delete<Role>(Role t) where Role : class
        {
            return ri.Delete<Role>(t);
        }
        //分页查询
        public List<Role> FenYe(Expression<Func<Role, int>> order, Expression<Func<Role, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return ri.FenYe(order, where, out rows,out pages, currentPage, pageSize);
        }

        public List<Role> SelectWhere(Expression<Func<Role, bool>> where)
        {
            return ri.SelectWhere(where);
        }

        public List<Role> Show<Role>() where Role : class
        {
            return ri.SelectAll<Role>();
        }

        public int Update<Role>(Role t) where Role : class
        {
            return ri.Update<Role>(t);
        }
    }
}
