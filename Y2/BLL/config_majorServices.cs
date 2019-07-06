using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using locContaniner;
using IBLL;
using IDAO;
using System.Linq.Expressions;

namespace BLL
{
    public class config_majorServices : config_majorIBLL
    {
        config_majorIDAO cmi = IocCreate.CreateProductTypeDao<config_majorIDAO>("containerOne", "config_majorDao");

        public List<config_major> config_majorCha()
        {
            return cmi.config_majorSelect<config_major>();
        }

        public List<config_major> config_majorChaID(Expression<Func<config_major, bool>> where)
        {
            return cmi.config_majorSelectID(where);
        }

        public int config_majorDel(config_major t)
        {
            return cmi.config_majorDelete(t);
        }

        public List<config_major> config_majorIDCha(Expression<Func<config_major, bool>> where)
        {
            return cmi.config_majorIDSelect(where);
        }

        public int config_majorAdd(config_major t)
        {
            return cmi.config_majorInsert(t);
        }
    }
}
