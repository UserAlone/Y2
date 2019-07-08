using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using IBLL;
using locContaniner;
using Model;

namespace BLL
{
    public class human_fileBLL : human_fileIBLL
    {
        human_fileIDAO hfDAO = IocCreate.CreateProductTypeDao<human_fileIDAO>("human_file", "human_fileDAO");

        //获取一级机构的数根据机构id查询
        public List<human_file> GetFirstConfigByID(object id)
        {
            return hfDAO.GetFirstConfigByID(id);
        }

        //获取三级级机构的数根据机构id查询
        public List<human_file> GetThridConfigByID(object id)
        {
            return hfDAO.GetThridConfigByID(id);
        }


        //获取二级级机构的数根据机构id查询
        public List<human_file> GetTwoConfigByID(object id)
        {
            return hfDAO.GetTwoConfigByID(id);
        }
    }
}
