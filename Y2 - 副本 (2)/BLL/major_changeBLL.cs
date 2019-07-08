using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IDAO;
using locContaniner;
using Model;
using System.Linq.Expressions;

namespace BLL
{
    public class major_changeBLL : major_changeIBLL
    {
        major_changeIDAO mc = IocCreate.CreateProductTypeDao<major_changeIDAO>("DDOne", "major_changeBAL");
        public DataTable FenYe(int currentPage, ref int page, ref int rows, string where)
        {
            return mc.FenYe(currentPage,ref page,ref rows,where);
        }
        //分页查询调动审核
        public DataTable FenYe2(int currentPage, ref int page, ref int rows, string where)
        {
            return mc.FenYe2(currentPage,ref page,ref rows,where);
        }

        public List<human_file> SelectWhere(Expression<Func<human_file, bool>> where)
        {
            return mc.SelectWhere(where);
        }
    }
}
