using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface config_major_kindIBLL
    {
        List<config_major_kind> config_major_kindCha();
        List<config_major_kind> config_major_kindChaID(Expression<Func<config_major_kind, bool>> where);
        int config_major_kindInsert(config_major_kind t);
        int config_major_kindDel(config_major_kind t);
    }
}
