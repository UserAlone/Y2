using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using locContaniner;
using IBLL;
using IDAO;
using Model;
using System.Linq.Expressions;

namespace BLL
{
    public class salary_standard_detailsServices : salary_standard_detailsIIBLL
    {
        salary_standard_detailsIDAO ssdi = IocCreate.CreateProductTypeDao<salary_standard_detailsIDAO>("containerOne", "salary_standard_detailsDao");
        public List<salary_standard_details> salary_standard_detailsCha()
        {
            return ssdi.salary_standard_detailsSelect<salary_standard_details>();
        }

        public List<salary_standard_details> salary_standard_detailsXiuCha(Expression<Func<salary_standard_details, bool>> where)
        {
            return ssdi.salary_standard_detailsUpdateCha(where);
        }
    }
}
