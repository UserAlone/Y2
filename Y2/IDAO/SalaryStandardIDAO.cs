using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface SalaryStandardIDAO
    {
        int AddSalaryStandard(salary_standard ss);
        //是否存在的单号
        object IsContainer(string danhao);
        List<salary_standard> FindByPage(Page<salary_standard> p);
        salary_standard FindByStandardId(string standardId);
        //查询没有复核的薪酬标准
        List<salary_standard> FindByCheckStatus(Page<salary_standard> p);
        //根据ssd_id 查询薪酬标准
        salary_standard FindByssd_id(object ssd_id);
        //根据ssd_id复核薪酬标准
        int ReviewByssd_id(salary_standard ss);
        //带条件获取薪酬标准登记查询数据
        List<salary_standard> GetByWhere(Page<salary_standard> p);
        //根据条件查询薪酬标准登记还没变更的数据
        List<salary_standard> FindByWhereAndChangeStaus(Page<salary_standard> p);

        //根据薪酬标准单编号变更
        int ChangeByStandardId(salary_standard ss);
    }
}
