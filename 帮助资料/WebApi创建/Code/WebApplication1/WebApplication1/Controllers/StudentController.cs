using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using Model;
using Newtonsoft.Json;
namespace WebApplication1.Controllers
{
    public class StudentController : ApiController
    {
        A3189Entities aet = new A3189Entities();
        public List<Book> GetBookSelect() {
           
          return aet.Book.Select(e => e).ToList();
         
        }

        public Book GetBookSelect(int id) {
            return aet.Book.Where(e => e.Bid == id).FirstOrDefault();
        }

        public int PostBookAdd([FromBody]Book book) {

            aet.Entry<Book>(book).State = System.Data.Entity.EntityState.Added;
            return aet.SaveChanges();
        }

        public int DeleteBook(int id) {

          Book b=  aet.Book.Where(e => e.Bid.Equals(id)).FirstOrDefault();
            aet.Book.Remove(b);
            return aet.SaveChanges();
        }

        public int PutBook([FromBody]Book book) {

            aet.Entry<Book>(book).State = System.Data.Entity.EntityState.Modified;
            return aet.SaveChanges();
           //int result= DeleteBook(id);
           // int result2 = PostBookAdd(book);
           // if (result==1&&result2==1)
           // {
           //     return 1;
           // }
           // else
           // {
           //     return 0;
           // }
        }
    }
}
