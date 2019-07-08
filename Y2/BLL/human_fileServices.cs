using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using locContaniner;
using Model;
using IDAO;
using IBLL;
using System.Linq.Expressions;

namespace BLL
{
    public class human_fileServices : human_fileIBLL
    {
        human_fileIDAO hfi = IocCreate.CreateProductTypeDao<human_fileIDAO>("containerOne", "human_fileDao");

        public int human_fileAdd(human_file t)
        {
            return hfi.human_fileInsert(t);
        }

        public List<human_file> human_fileCha()
        {
            return hfi.human_fileSelect<human_file>();
        }

        public int human_fileDel2(string sql)
        {
            return hfi.human_fileDelete2(sql);
        }

        public int human_fileDel(engage_resume t)
        {
            return hfi.human_fileDelete(t);
        }

        public List<human_file> human_fileFY<K>(Expression<Func<human_file, K>> order, Expression<Func<human_file, bool>> where, out int rows, out int pages, int currentPage, int pageSize)
        {
            return hfi.human_fileFenYe<human_file, K>(order, where, out rows, out pages, currentPage, pageSize);
        }

        public List<human_file> human_fileSelectCha(Expression<Func<human_file, bool>> where)
        {
            return hfi.human_fileSelectCha(where);
        }

        public int human_fileXiu(human_file t)
        {
            return hfi.human_fileUpdate(t);
        }
        public List<config_file_first_kind> SelectAll<config_file_first_kind>() where config_file_first_kind : class
        {
            return hfi.SelectAll<config_file_first_kind>();
        }

        public List<config_file_second_kind> SelectWhere(Expression<Func<config_file_second_kind, bool>> where)
        {
            return hfi.SelectWhere<config_file_second_kind>(where);
        }
    }
}
