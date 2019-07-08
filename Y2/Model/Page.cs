using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Page<T>
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public string KeyName { get; set; }
        public string TableName { get; set; }
        public List<T> Data { get; set; }
        public string Where { get; set; }
    }
}
