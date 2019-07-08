using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using locContaniner;
using BLL;
using IBLL;
using Model;
using BAL;


namespace UI.Controllers
{
    public class clientController : Controller
    {
        config_file_first_kindIBLL cffkBLL = IocCreate.CreateProductTypeBLL<config_file_first_kindIBLL>("config_file_first_kind", "config_file_first_kindBLL");
        config_file_second_kindIBLL cfskBLL = IocCreate.CreateProductTypeBLL<config_file_second_kindIBLL>("config_file_second_kind", "config_file_second_kindBLL");
        config_file_third_kindIBLL cftkBLL = IocCreate.CreateProductTypeBLL<config_file_third_kindIBLL>("config_file_third_kind", "config_file_third_kindBLL");
        //I级机构设置页面
        public ActionResult first_kind()
        {
            List<config_file_first_kind> list = cffkBLL.GetAll();
            return View(list);
        }

        //根据主键，自动增长列删除一级结构数据
        public ActionResult DelByffk_id(string id)
        {
            string flag = "删除失败";
            int res = cffkBLL.DelByffk_id(id);
            if (res > 0)
            {
                flag = "删除成功";
            }
            return Content("<script>alert('" + flag + "');window.location.href='/client/first_kind'</script>");
        }

        //I级机构设置--I级机构添加页面
        public ActionResult first_kind_register()
        {
            return View();
        }

        //创建一级结构一级机构编号  
        public ActionResult Createfirst_kind_id()
        {
            string id = string.Empty;
            object temp = cffkBLL.GetMaxfirst_kind_id();
            if (temp == null)
            {
                id = "01";
            }
            else
            {
                if (Convert.ToInt32(temp.ToString()) > 9)
                {
                    id = (Convert.ToInt32(temp.ToString()) + 1).ToString();
                }
                else
                {
                    id = "0" + (Convert.ToInt32(temp.ToString()) + 1);
                }
            }
            return Content(id);
        }

        //增加一级结构数据
        public ActionResult Addconfig_file_first_kind(config_file_first_kind cffk)
        {
            int res = cffkBLL.Add(cffk);
            if (res > 0)
            {
                return Content("<script>alert('添加成功');window.location.href='/client/first_kind'</script>");
            }
            return Content("<script>alert('添加失败');window.location.href='/client/first_kind_register'</script>");
        }

        //级机构设置--I级机构变更页面
        public ActionResult first_kind_change(string id)
        {
            config_file_first_kind cffk = cffkBLL.GetByffk_id(id);
            return View(cffk);
        }

        public ActionResult Updateconfig_file_first_kind(config_file_first_kind cffk)
        {         
            int res = cffkBLL.Update(cffk);
            if (res>0)
            {
                return Content("<script>alert('更改成功');window.location.href='/client/first_kind'</script>");
            }
            return Content("<script>alert('更改失败');window.location.href='/client/Updateconfig_file_first_kind'</script>");
        }

        //II级机构设置
        public ActionResult second_kind()
        {
            List<config_file_second_kind> list = cfskBLL.GetAll();
            return View(list);
        }

        //根据fsk_id 删除
        public ActionResult DelByfsk_id(string id)
        {
            int res = cfskBLL.DelByfsk_id(id);
            if (res>0)
            {
                return Content("<script>alert('删除成功');window.location.href='/client/second_kind'</script>");
            }
            return Content("<script>alert('删除失败');window.location.href='/client/second_kind'</script>");
        }
        //创建fsk_id
        public ActionResult Createfsk_id()
        {
            string id = string.Empty;
            object temp = cfskBLL.GetMaxsecond_kind_id();
            if (temp == null)
            {
                id = "01";
            }
            else
            {
                if (Convert.ToInt32(temp.ToString()) > 9)
                {
                    id = (Convert.ToInt32(temp.ToString()) + 1).ToString();
                }
                else
                {
                    id = "0" + (Convert.ToInt32(temp.ToString()) + 1);
                }
            }
            return Content(id);
        }

        public ActionResult second_kind_register()
        {
            ViewData["一级机构数据"] = cffkBLL.GetAll();
            return View();
        }

        //添加二级机构设置
        public ActionResult Addconfig_file_second_kind(config_file_second_kind cfsk)
        {
            int res = cfskBLL.Add(cfsk);
            if (res>0)
            {
                return Content("<script>alert('添加成功');window.location.href='/client/second_kind'</script>");
            }
            return Content("<script>alert('添加成功');window.location.href='/client/second_kind_register'</script>");
        }

        public ActionResult second_kind_change(string id)
        {
            config_file_second_kind cfsk = cfskBLL.GetByfsk_id(id);
            return View(cfsk);
        }

        public ActionResult Updateconfig_file_second_kind(config_file_second_kind cfsk)
        {
            int res = cfskBLL.Update(cfsk);        
            if (res > 0)
            {
                return Content("<script>alert('更改成功');window.location.href='/client/second_kind'</script>");
            }
            return Content("<script>alert('更改成功');window.location.href='/client/second_kind_change'</script>");
        }

        //III级机构设置
        public ActionResult third_kind()
        {
            List<config_file_third_kind> list = cftkBLL.GetAll();
            return View(list);
        }

        //三级结构添加页面
        public ActionResult third_kind_register()
        {
            ViewData["一级"] = cffkBLL.GetAll();
            ViewData["二级"] = cfskBLL.GetAll();
            ViewData["third_kind_id"] = Createthird_kind_id(cftkBLL.GetMaxthird_kind_id());
            return View();
        }

        //创建third_kind_id 
        public string Createthird_kind_id(object temp)
        {
            string id = string.Empty;           
            if (temp == null)
            {
                id = "01";
            }
            else
            {
                if (Convert.ToInt32(temp.ToString()) > 9)
                {
                    id = (Convert.ToInt32(temp.ToString()) + 1).ToString();
                }
                else
                {
                    id = "0" + (Convert.ToInt32(temp.ToString()) + 1);
                }
            }
            return id;
        }

        public ActionResult Addconfig_file_third_kind(config_file_third_kind cftk)
        {
            int res = cftkBLL.Add(cftk);
            if (res > 0)
            {
                return Content("<script>alert('添加成功');window.location.href='/client/third_kind'</script>");
            }
            return Content("<script>alert('添加成功');window.location.href='/client/third_kind_register'</script>");
        }

        public ActionResult Delconfig_file_third_kind(string id)
        {
            int res = cftkBLL.Del(id);
            if (res > 0)
            {
                return Content("<script>alert('删除成功');window.location.href='/client/third_kind'</script>");
            }
            return Content("<script>alert('删除失败');window.location.href='/client/third_kind'</script>");
        }

        public ActionResult third_kind_change(string id)
        {
            config_file_third_kind cftk = cftkBLL.GetBythird_kind_id(id);
            return View(cftk);
        }

        public ActionResult Updateconfig_file_third_kind(config_file_third_kind cftk)
        {
            int res = cftkBLL.Update(cftk);
            if (res > 0)
            {
                return Content("<script>alert('更改成功');window.location.href='/client/third_kind'</script>");
            }
            return Content("<script>alert('更改成功');window.location.href='/client/third_kind_change'</script>");
        }
    }
}