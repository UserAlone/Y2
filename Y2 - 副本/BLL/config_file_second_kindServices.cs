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
    public class config_file_second_kindServices : config_file_second_kindIBLL
    {
        config_file_second_kindIDAO cfsk = IocCreate.CreateProductTypeDao<config_file_second_kindIDAO>("containerOne", "config_file_second_kindDao");

        public List<config_file_second_kind> config_file_second_kindCha()
        {
            return cfsk.config_file_second_kindSelect<config_file_second_kind>();
        }

        public List<config_file_second_kind> config_file_second_kindChaID(Expression<Func<config_file_second_kind, bool>> where)
        {
            return cfsk.config_file_second_kindSelectID(where);
        }

        public List<config_file_second_kind> config_file_second_kindIDCha(Expression<Func<config_file_second_kind, bool>> where)
        {
            return cfsk.config_file_second_kindIDSelect(where);
        }
    }
}
