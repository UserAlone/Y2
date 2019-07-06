using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface userIDAO
    {
        List<T> userSelect<T>() where T : class;
    }
}
