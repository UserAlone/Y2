using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface config_file_second_kindIBLL
    {
        List<config_file_second_kind> config_file_second_kindCha();
        List<config_file_second_kind> config_file_second_kindIDCha(Expression<Func<config_file_second_kind, bool>> where);
        List<config_file_second_kind> config_file_second_kindChaID(Expression<Func<config_file_second_kind, bool>> where);
    }
}
