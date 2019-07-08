using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface config_file_third_kindIBLL
    {
        //获取三级机构的基本总金额和人数
        List<Dictionary<string, object>> GetByThird();

        List<config_file_third_kind> GetAll();

        int Add(config_file_third_kind cfftk);

        object GetMaxthird_kind_id();

        int Del(object id);

        config_file_third_kind GetBythird_kind_id(object id);

        int Update(config_file_third_kind cftk);
    }
}
