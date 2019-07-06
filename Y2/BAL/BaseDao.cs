using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace BAL
{
    public class BaseDao
    {
        HR_DBEntities hde = CreateDBContent();
        public static HR_DBEntities CreateDBContent()
        {

            HR_DBEntities at = CallContext.GetData("s") as HR_DBEntities;
            if (at == null)
            {
                at = new HR_DBEntities();
                CallContext.SetData("s", at);
            }
            return at;

        }
        public List<T> SelectAll<T>()where T:class
        {                       
            return hde.Set<T>().Select(e => e).AsNoTracking().ToList();
        }
        public List<T> SelectWhere<T>(Expression<Func<T, bool>> where) where T : class
        {
            return hde.Set<T>().Where(where).AsNoTracking()
                  .Select(e => e)
                  .ToList();
        }

        public List<T> FenYe<T,K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, out int rows,out int pages, int currentPage, int pageSize) where T : class
        {
            var data = hde.Set<T>().OrderBy(order).Where(where);
            rows = data.Count();
            pages = (data.Count() + pageSize - 1) / pageSize;
            return data.Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
        }

        public int Add<T>(T t) where T : class
        {
            hde.Entry<T>(t).State = EntityState.Added;
            return hde.SaveChanges();
        }

        public int Update<T>(T t) where T : class
        {
            hde.Entry<T>(t).State = EntityState.Modified;
            hde.Configuration.ValidateOnSaveEnabled = false;
            return hde.SaveChanges();
        }

        public int Delete<T>(T t) where T : class
        {
            hde.Entry<T>(t).State = EntityState.Deleted;
            return hde.SaveChanges();
        }

        public int AUD(string sql) 
        {
            return hde.Database.ExecuteSqlCommand(sql);
        }
    }
}
