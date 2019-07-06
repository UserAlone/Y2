using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using locContaniner;
using IDAO;
using IBLL;

namespace BLL
{
    public class userServices : userIBLL
    {
        userIDAO ui = IocCreate.CreateProductTypeDao<userIDAO>("containerOne", "userDao");
        public List<Users> userCha()
        {
            return ui.userSelect<Users>();
        }
    }
}
