using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface config_file_first_kindIBLL
    {
            
        //获取一级机构的基本总金额和人数
        List<Dictionary<string, object>> GetByFirst();

        /// <summary>
        /// 获取所有一级机构的数据
        /// </summary>
        /// <returns></returns>
        List<config_file_first_kind> GetAll();


        /// <summary>
        /// 根据主键，自动增长列删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelByffk_id(object id);

        /// <summary>
        /// 获取最大的一级机构编号
        /// </summary>
        /// <returns></returns>
        object GetMaxfirst_kind_id();

        /// <summary>
        /// 增加一级结构数据
        /// </summary>
        /// <returns></returns>
        int Add(config_file_first_kind cffk);

        config_file_first_kind GetByffk_id(object id);

        int Update(config_file_first_kind cffk);
    }
}
