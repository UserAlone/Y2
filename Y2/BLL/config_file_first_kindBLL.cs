using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IBLL;
using IDAO;
using locContaniner;

namespace BLL
{
    public class config_file_first_kindBLL : config_file_first_kindIBLL
    {
        config_file_first_kindIDAO cffkDAO = IocCreate.CreateProductTypeDao<config_file_first_kindIDAO>("config_file_first_kind", "config_file_first_kindDAO");

        public int Add(config_file_first_kind cffk)
        {
            return cffkDAO.Add(cffk);
        }

        /// <summary>
        /// 根据主键，自动增长列删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelByffk_id(object id)
        {
            return cffkDAO.DelByffk_id(id);
        }

        /// <summary>
        /// 获取所有一级机构的数据
        /// </summary>
        /// <returns></returns>
        public List<config_file_first_kind> GetAll()
        {
            return cffkDAO.GetAll();
        }

        public config_file_first_kind GetByffk_id(object id)
        {
            return cffkDAO.GetByffk_id(id);
        }

        //获取一级机构的基本总金额和人数
        public List<Dictionary<string, object>> GetByFirst()
        {
            return cffkDAO.GetByFirst();
        }

        /// <summary>
        /// 获取最大的一级机构编号
        /// </summary>
        /// <returns></returns>
        public object GetMaxfirst_kind_id()
        {
            return cffkDAO.GetMaxfirst_kind_id();
        }

        public int Update(config_file_first_kind cffk)
        {
            return cffkDAO.Update(cffk);
        }
    }
}
