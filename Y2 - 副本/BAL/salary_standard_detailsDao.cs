using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;

namespace BAL
{
    public class salary_standard_detailsDao : BaseDao, salary_standard_detailsIDAO
    {
        public List<T> salary_standard_detailsSelect<T>() where T : class
        {
            return SelectAll<T>();
        }

        public List<T> salary_standard_detailsUpdateCha<T>(Expression<Func<T, bool>> where) where T : class
        {
            return SelectWhere(where);
        }
    }
}
