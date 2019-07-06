using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IBLL;
using IDAO;
using locContaniner;
using System.Linq.Expressions;

namespace BLL
{
    public class engage_major_releaseServices : engage_major_releaseIBLL
    {
        engage_major_releaseIDAO emri = IocCreate.CreateProductTypeDao<engage_major_releaseIDAO>("containerOne", "engage_major_releaseDao");

        public int engage_major_releaseAdd(engage_major_release emr)
        {
            return emri.engage_major_releaseInsert(emr);
        }

        public int engage_major_releaseDel(engage_major_release t)
        {
            return emri.engage_major_releaseDelete(t);
        }

        public List<engage_major_release> engage_major_releaseFY<K>(Expression<Func<engage_major_release, K>> order, Expression<Func<engage_major_release, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return emri.engage_major_releaseFenYe<engage_major_release, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public int engage_major_releaseXiu(engage_major_release t)
        {
            return emri.engage_major_releaseUpdate(t);
        }

        public List<engage_major_release> engage_major_releaseXiuCha(Expression<Func<engage_major_release, bool>> where)
        {
            return emri.engage_major_releaseUpdateCha(where);
        }
    }
}
