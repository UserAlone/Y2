using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface salary_standard_detailsIDAO
    {
        List<T> salary_standard_detailsSelect<T>() where T : class;
        List<T> salary_standard_detailsUpdateCha<T>(Expression<Func<T, bool>> where) where T : class;
    }
}
