using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface SalaryStandardIBLL
    {
        int AddSalaryStandard(salary_standard ss);
        object IsContainer(string danhao);
        Page<salary_standard> FindByPage(Dictionary<string,object> dic);
        salary_standard FindByStandardId(string standardId);

        //查询没有复核的薪酬标准
        Page<salary_standard> FindByCheckStatus(Dictionary<string,object> dic);

        //根据ssd_id 查询薪酬标准
        salary_standard FindByssd_id(object ssd_id);

        //根据ssd_id复核薪酬标准
        int UpdateByssd_id(salary_standard ss);

        //带条件获取薪酬标准登记查询数据
        Page<salary_standard> GetByWhere(Dictionary<string, object> dic);

        //根据条件查询薪酬标准登记还没变更的数据
        Page<salary_standard> FindByWhereAndChangeStaus(Dictionary<string,object> dic);

        //根据薪酬标准单编号变更
        int ChangeByStandardId(salary_standard ss);


        int ReviewByssd_id(salary_standard ss);
    }
}
