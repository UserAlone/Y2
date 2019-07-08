using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface SalaryStandardDetailsIBLL
    {
        int AddSalaryStandardDetails(salary_standard_details ssd);
        List<salary_standard_details> FindByStandardID(string standardID);

        //根据ssd_id复核薪酬标准单详细信息
        int ReviewBystandard_id(salary_standard_details ssd);

        //变更薪酬标准单详细信息
        int ChangeByStandardID(salary_standard_details ssd);

        //查询所有
        List<salary_standard_details> FindAll();
    }
}
