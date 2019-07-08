using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAO;
using locContaniner;
using IBLL;

namespace BLL
{
    public class config_file_second_kindBLL : config_file_second_kindIBLL
    {
        config_file_second_kindIDAO cffkDAO = IocCreate.CreateProductTypeDao<config_file_second_kindIDAO>("config_file_second_kind", "config_file_second_kindDAO");

        public int Add(config_file_second_kind cfsk)
        {
            return cffkDAO.Add(cfsk);
        }

        public int DelByfsk_id(object id)
        {
            return cffkDAO.DelByfsk_id(id);
        }

        public List<config_file_second_kind> GetAll()
        {
            return cffkDAO.GetAll();
        }

        public config_file_second_kind GetByfsk_id(object id)
        {
            return cffkDAO.GetByfsk_id(id);
        }

        //获取一级机构的基本总金额和人数
        public List<Dictionary<string, object>> GetByTwo()
        {
            return cffkDAO.GetByTwo();
        }

        public object GetMaxsecond_kind_id()
        {
            return cffkDAO.GetMaxsecond_kind_id();
        }

        public int Update(config_file_second_kind cfsk)
        {
            return cffkDAO.Update(cfsk);
        }
    }
}
