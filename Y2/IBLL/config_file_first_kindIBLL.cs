using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface config_file_first_kindIBLL
    {
        List<config_file_first_kind> config_file_first_kindCha();

        List<config_file_first_kind> config_file_first_kindChaID(Expression<Func<config_file_first_kind, bool>> where);
    }
}
