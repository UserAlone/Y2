using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface human_fileIBLL
    {
        //获取一级机构的数根据机构id查询
        List<human_file> GetFirstConfigByID(object id);

        //获取二级级机构的数根据机构id查询
        List<human_file> GetTwoConfigByID(object id);

        //获取三级级机构的数根据机构id查询
        List<human_file> GetThridConfigByID(object id);
    }
}

