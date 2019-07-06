using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface config_public_charIBLL
    {
        List<config_public_char> config_public_charIDcha(Expression<Func<config_public_char, bool>> where);
        List<config_public_char> config_public_charCha();
        int config_public_charAdd(config_public_char t);
        int config_public_charDelete(config_public_char t);
    }
}
