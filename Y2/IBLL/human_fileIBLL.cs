using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public interface human_fileIBLL
    {
        List<human_file> human_fileCha();
        int human_fileAdd(human_file t);
        List<human_file> human_fileSelectCha(Expression<Func<human_file, bool>> where);
        int human_fileXiu(human_file t);
        List<human_file> human_fileFY<K>(Expression<Func<human_file, K>> order, Expression<Func<human_file, bool>> where, out int rows, out int pages, int currentPage, int pageSize);
        int human_fileDel(engage_resume t);
        int human_fileDel2(string sql);
    }
}
