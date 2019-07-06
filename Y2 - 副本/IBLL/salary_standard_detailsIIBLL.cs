using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface salary_standard_detailsIIBLL
    {
        List<salary_standard_details> salary_standard_detailsCha();
        List<salary_standard_details> salary_standard_detailsXiuCha(Expression<Func<salary_standard_details, bool>> where);
    }
}
