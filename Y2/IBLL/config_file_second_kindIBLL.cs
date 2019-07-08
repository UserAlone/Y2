using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface config_file_second_kindIBLL
    {

        //获取一级机构的基本总金额和人数
        List<Dictionary<string, object>> GetByTwo();

        List<config_file_second_kind> GetAll();

        int DelByfsk_id(object id);

        int Add(config_file_second_kind cfsk);

        object GetMaxsecond_kind_id();

        int Update(config_file_second_kind cfsk);

        config_file_second_kind GetByfsk_id(object id);
    }
}
