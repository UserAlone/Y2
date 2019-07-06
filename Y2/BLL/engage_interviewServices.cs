using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using locContaniner;
using Model;

namespace BLL
{
    public class engage_interviewServices : engage_interviewIBLL
    {
        engage_interviewIDAO eii = IocCreate.CreateProductTypeDao<engage_interviewIDAO>("containerOne", "engage_interviewDao");

        public int engage_interviewAdd(engage_interview t)
        {
            return eii.engage_interviewInsert(t);
        }

        public List<engage_interview> engage_interviewCha()
        {
            return eii.engage_interviewSelect<engage_interview>();
        }

        public List<engage_interview> engage_interviewChaID(Expression<Func<engage_interview, bool>> where)
        {
            return eii.engage_interviewSelectID(where);
        }

        public int engage_interviewDel(string sql)
        {
            return eii.engage_interviewDelete(sql);
        }

        public int engage_interviewXiu(engage_interview t)
        {
            return eii.engage_interviewUpdate(t);
        }

        public List<engage_interview> engage_major_releaseFY<K>(Expression<Func<engage_interview, K>> order, Expression<Func<engage_interview, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return eii.engage_interviewFenYe<engage_interview, K>(order, where, out rows, out pages, currentPage, pageSize);
        }
    }
}
