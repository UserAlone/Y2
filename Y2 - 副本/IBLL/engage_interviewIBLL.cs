using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface engage_interviewIBLL
    {
        List<engage_interview> engage_interviewCha();
        List<engage_interview> engage_interviewChaID(Expression<Func<engage_interview, bool>> where);
        int engage_interviewAdd(engage_interview t);
        int engage_interviewXiu(engage_interview t);
        List<engage_interview> engage_major_releaseFY<K>(Expression<Func<engage_interview, K>> order, Expression<Func<engage_interview, bool>> where, out int rows, out int pages, int currentPage, int pageSize);
        int engage_interviewDel(string sql);
    }
}
