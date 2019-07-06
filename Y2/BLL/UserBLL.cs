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
    public class UserBLL : UserIBLL
    {
        UserIDAO ui = IocCreate.CreateProductTypeDao<UserIDAO>("DlOne", "UserBAL");
        public List<Users> SelectWhere(Expression<Func<Users, bool>> where)
        {
            return ui.SelectWhere<Users>(where);
        }
    }
}
