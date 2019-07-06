using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IBLL
{
   public interface UserIBLL
    {
        //查询单行
        List<Users> SelectWhere(Expression<Func<Users, bool>> where);
    }
}
