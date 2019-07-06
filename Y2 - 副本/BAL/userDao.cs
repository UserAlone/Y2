using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Model;

namespace BAL
{
    public class userDao : BaseDao, userIDAO
    {
        public List<T> userSelect<T>() where T : class
        {
            return SelectAll<T>();
        }
    }
}
