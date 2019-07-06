using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IBLL;
using IDAO;
using locContaniner;
using System.Linq.Expressions;

namespace BLL
{
    public class config_file_third_kindServices : config_file_third_kindIBLL
    {
        config_file_third_kindIDAO cftk = IocCreate.CreateProductTypeDao<config_file_third_kindIDAO>("containerOne", "config_file_third_kindDao");

        public List<config_file_third_kind> config_file_third_kindCha()
        {
            return cftk.config_file_third_kindISelect<config_file_third_kind>();
        }

        public List<config_file_third_kind> config_file_third_kindChaID(Expression<Func<config_file_third_kind, bool>> where)
        {
            return cftk.config_file_third_kindSelectID(where);
        }

        public List<config_file_third_kind> config_file_third_kindIDCha(Expression<Func<config_file_third_kind, bool>> where)
        {
            return cftk.config_file_third_kindIDSelect(where);
        }
    }
}
