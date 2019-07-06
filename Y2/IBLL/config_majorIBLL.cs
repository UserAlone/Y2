using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface config_majorIBLL
    {
        List<config_major> config_majorCha();
        List<config_major> config_majorIDCha(Expression<Func<config_major, bool>> where);
        List<config_major> config_majorChaID(Expression<Func<config_major, bool>> where);
        int config_majorAdd(config_major t);
        int config_majorDel(config_major t);
    }
}
