using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface engage_major_releaseIBLL
    {
        int engage_major_releaseAdd(engage_major_release emr);
        List<engage_major_release> engage_major_releaseFY<K>(Expression<Func<engage_major_release, K>> order, Expression<Func<engage_major_release, bool>> where, out int rows, out int pages, int currentPage, int pageSize);
        List<engage_major_release> engage_major_releaseXiuCha(Expression<Func<engage_major_release, bool>> where);
        int engage_major_releaseXiu(engage_major_release t);
        int engage_major_releaseDel(engage_major_release t);
    }
}
