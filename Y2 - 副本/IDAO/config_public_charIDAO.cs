using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface config_public_charIDAO
    {
        List<T> config_public_charIDcha<T>(Expression<Func<T, bool>> where) where T : class;
        List<T> config_public_charSelect<T>() where T : class;
        int config_public_charInsert<T>(T t) where T : class;
        int config_public_charDelete<T>(T t) where T : class;
    }
}
