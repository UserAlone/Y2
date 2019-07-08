using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using locContaniner;
using BAL;
using Model;

namespace BLL
{
    public class SalaryStandardDetailsBLL : SalaryStandardDetailsIBLL
    {
        SalaryStandardDetailsIDAO ssdDAO = IocCreate.CreateProductTypeDao<SalaryStandardDetailsIDAO>("SalaryStandardDetails", "SalaryStandardDetailsDAO");
        public int AddSalaryStandardDetails(salary_standard_details ssd)
        {
            return ssdDAO.AddSalaryStandardDetails(ssd);
        }

        //变更薪酬标准单详细信息      
        public int ChangeByStandardID(salary_standard_details ssd)
        {
            return ssdDAO.ChangeByStandardID(ssd);
        }

        public List<salary_standard_details> FindAll()
        {
            return ssdDAO.FindAll();
        }

        public List<salary_standard_details> FindByStandardID(string standardID)
        {
            return ssdDAO.FindByStandardID(standardID);
        }

        public int ReviewBystandard_id(salary_standard_details ssd)
        {
            return ssdDAO.ReviewBystandard_id(ssd);
        }
    }
}
