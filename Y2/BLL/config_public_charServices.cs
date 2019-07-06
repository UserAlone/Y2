using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using locContaniner;
using Model;
using IDAO;
using IBLL;
using System.Linq.Expressions;

namespace BLL
{
    public class config_public_charServices : config_public_charIBLL
    {
        config_public_charIDAO cpc = IocCreate.CreateProductTypeDao<config_public_charIDAO>("containerOne", "config_public_charDao");

        public int config_public_charAdd(config_public_char t)
        {
            return cpc.config_public_charInsert(t);
        }

        public List<config_public_char> config_public_charCha()
        {
            return cpc.config_public_charSelect<config_public_char>();
        }

        public int config_public_charDelete(config_public_char t)
        {
            return cpc.config_public_charDelete(t);
        }

        public List<config_public_char> config_public_charIDcha(Expression<Func<config_public_char, bool>> where)
        {
            return cpc.config_public_charIDcha(where);
        }
    }
}
