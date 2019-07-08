using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using locContaniner;
using IDAO;
using IBLL;
using System.Linq.Expressions;

namespace BLL
{
    public class userServices : userIBLL
    {
        userIDAO ui = IocCreate.CreateProductTypeDao<userIDAO>("containerOne", "userDao");
        public List<Users> SelectWhere(Expression<Func<Users, bool>> where)
        {
            return ui.SelectWhere<Users>(where);
        }
        public List<Users> userCha()
        {
            return ui.userSelect<Users>();
        }
    }
}
