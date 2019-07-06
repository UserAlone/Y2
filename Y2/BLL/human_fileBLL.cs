using IBLL;
using IDAO;
using locContaniner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace BLL
{
    public class human_fileBLL : human_fileIBLL
    {
        human_fileIDAO ri = IocCreate.CreateProductTypeDao<human_fileIDAO>("DdOne", "human_fileBAL");

        public List<config_file_first_kind> SelectAll<config_file_first_kind>() where config_file_first_kind : class
        {
            return ri.SelectAll<config_file_first_kind>();
        }

        public List<config_file_second_kind> SelectWhere(Expression<Func<config_file_second_kind, bool>> where)
        {
            return ri.SelectWhere<config_file_second_kind>(where);
        }
    }
}
