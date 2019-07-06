using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
namespace WebApplication3.Controllers
{
    public class StuentController : Controller
    {
        // GET: Stuent
        public async Task<ActionResult> Index()
        {
            //需求：调用WebApi中的Get
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:2726/");
            HttpResponseMessage hp= await  hc.GetAsync("api/student");
            List<Book> result = await hp.Content.ReadAsAsync<List<Book>>();

            return View(result);
        }
    }
}