using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface engage_resumeIBLL
    {
        int engage_resumeAdd(engage_resume t);
        List<engage_resume> engage_resumeSelect();
        List<engage_resume> engage_releaseFY<K>(Expression<Func<engage_resume, K>> order, Expression<Func<engage_resume, bool>> where, out int rows, out int pages, int currentPage, int pageSize);
        List<engage_resume> engage_resumeXiuCha(Expression<Func<engage_resume, bool>> where);
        int engage_resumeXiu(engage_resume t);
        int engage_resumeDel(engage_resume t);
        List<engage_resume> engage_releaseFY2<K>(Expression<Func<engage_resume, K>> order, Expression<Func<engage_resume, bool>> where, out int rows, out int pages, int currentPage, int pageSize);
    }
}
