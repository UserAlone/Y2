using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using locContaniner;
using IDAO;
using IBLL;
using System.Linq.Expressions;

namespace BLL
{
    public class engage_resumeServices : engage_resumeIBLL
    {
        engage_resumeIDAO er = IocCreate.CreateProductTypeDao<engage_resumeIDAO>("containerOne", "engage_resumeDao");

        public List<engage_resume> engage_releaseFY<K>(Expression<Func<engage_resume, K>> order, Expression<Func<engage_resume, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return er.engage_resumeFenYe<engage_resume, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public List<engage_resume> engage_releaseFY2<K>(Expression<Func<engage_resume, K>> order, Expression<Func<engage_resume, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return er.engage_resumeFenYe2<engage_resume, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int engage_resumeAdd(engage_resume t)
        {
            return er.engage_resumeInsert(t);
        }

        public int engage_resumeDel(engage_resume t)
        {
            return er.engage_resumeDelete(t);
        }

        public List<engage_resume> engage_resumeSelect()
        {
            return er.engage_resumeSelect<engage_resume>();
        }

        public int engage_resumeXiu(engage_resume t)
        {
            return er.engage_resumeUpdate(t);
        }

        public List<engage_resume> engage_resumeXiuCha(Expression<Func<engage_resume, bool>> where)
        {
            return er.engage_resumeUpdateCha(where);
        }
    }
}
