using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface userIBLL
    {
        List<Users> userCha();
        //查询单行
        List<Users> SelectWhere(Expression<Func<Users, bool>> where);
    }
}
