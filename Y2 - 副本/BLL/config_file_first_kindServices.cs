using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using IBLL;
using locContaniner;
using Model;
using BAL;
using System.Linq.Expressions;

namespace BLL
{
    public class config_file_first_kindServices : config_file_first_kindIBLL
    {
        config_file_first_kindIDAO cffk = IocCreate.CreateProductTypeDao<config_file_first_kindIDAO>("containerOne", "config_file_first_kindDao");
        public List<config_file_first_kind> config_file_first_kindCha()
        {
            return cffk.config_file_first_kindSelect<config_file_first_kind>();
        }

        public List<config_file_first_kind> config_file_first_kindChaID(Expression<Func<config_file_first_kind, bool>> where)
        {
            return cffk.config_file_first_kindSelectID(where);
        }
    }
}
