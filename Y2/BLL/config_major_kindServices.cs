using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using IBLL;
using Model;
using locContaniner;
using System.Linq.Expressions;

namespace BLL
{
    public class config_major_kindServices : config_major_kindIBLL
    {
        config_major_kindIDAO cmk = IocCreate.CreateProductTypeDao<config_major_kindIDAO>("containerOne", "config_major_kindDao");

        public List<config_major_kind> config_major_kindCha()
        {
            return cmk.config_major_kindSelect<config_major_kind>();
        }

        public List<config_major_kind> config_major_kindChaID(Expression<Func<config_major_kind, bool>> where)
        {
            return cmk.config_major_kindSelectID(where);
        }

        public int config_major_kindDel(config_major_kind t)
        {
            return cmk.config_major_kindDelete(t);
        }

        public int config_major_kindInsert(config_major_kind t)
        {
            return cmk.config_major_kindInsert(t);
        }
    }
}
