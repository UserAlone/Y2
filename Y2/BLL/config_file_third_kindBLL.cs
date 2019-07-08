using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using IBLL;
using locContaniner;

namespace BLL
{
    public class config_file_third_kindBLL : config_file_third_kindIBLL
    {
        config_file_third_kindIDAO cftkDAO = IocCreate.CreateProductTypeDao<config_file_third_kindIDAO>("config_file_third_kind", "config_file_third_kindDAO");

        public int Add(config_file_third_kind cfftk)
        {
            return cftkDAO.Add(cfftk);
        }

        public int Del(object id)
        {
            return cftkDAO.Del(id);
        }

        public List<config_file_third_kind> GetAll()
        {
            return cftkDAO.GetAll();
        }

        //获取三级机构的基本总金额和人数
        public List<Dictionary<string, object>> GetByThird()
        {
            return cftkDAO.GetByThird();
        }

        public config_file_third_kind GetBythird_kind_id(object id)
        {
            return cftkDAO.GetBythird_kind_id(id);
        }

        public object GetMaxthird_kind_id()
        {
            return cftkDAO.GetMaxthird_kind_id();
        }

        public int Update(config_file_third_kind cftk)
        {
            return cftkDAO.Update(cftk);
        }
    }
}
