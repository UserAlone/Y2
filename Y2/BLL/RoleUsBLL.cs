using IBLL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IDAO;
using locContaniner;
using Model;
namespace BLL
{
    public class RoleUsBLL : RoleUsIBLL
    {
        RoleUsIDAO ri = IocCreate.CreateProductTypeDao<RoleUsIDAO>("containerOne", "RoleUsBAL");
        public int Add<Users>(Users t) where Users : class
        {
            return ri.Add<Users>(t);
        }

        public int Delete<Users>(Users t) where Users : class
        {
            return ri.Delete<Users>(t);
        }
        //分页查询
        public List<RoleUs> FenYe(Expression<Func<RoleUs, int>> order, Expression<Func<RoleUs, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return ri.FenYe(order, where, out rows,out pages, currentPage, pageSize);
        }


        public List<Users> SelectWhere<Users>(Expression<Func<Users, bool>> where) where Users : class
        {
            return ri.SelectWhere<Users>(where);
        }
        //查询全部
        public List<RoleUs> Show<RoleUs>() where RoleUs : class
        {
            return ri.SelectAll<RoleUs>();
        }

        public int Update<Users>(Users t) where Users : class
        {
            return ri.Update<Users>(t);
        }
    }
}
