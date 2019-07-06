using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;

namespace BAL
{
    public class config_public_charDao : BaseDao, config_public_charIDAO
    {
        public List<T> config_public_charSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> config_public_charIDcha<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }

        public int config_public_charInsert<T>(T t) where T : class
        {
            return Add(t);
        }

        public int config_public_charDelete<T>(T t) where T : class
        {
            return Delete(t);
        }
    }
}
