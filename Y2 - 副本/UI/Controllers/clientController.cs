using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using locContaniner;
using Model;
using IBLL;

namespace UI.Controllers
{
    public class clientController : Controller
    {
        config_public_charIBLL cpci = IocCreate.CreateProductTypeBLL<config_public_charIBLL>("containerTwo", "config_public_charServices");
        config_major_kindIBLL cmki = IocCreate.CreateProductTypeBLL<config_major_kindIBLL>("containerTwo", "config_major_kindServices");
        config_majorIBLL cmi = IocCreate.CreateProductTypeBLL<config_majorIBLL>("containerTwo", "config_majorServices");
        //公共属性设置
        public ActionResult public_char()
        {
            ViewBag.list = cpci.config_public_charCha();
            return View();
        }
        public ActionResult public_char_add()
        {           
            return View();
        }
        //公共属性设置添加
        public ActionResult public_char_add2(config_public_char cpc)
        {
            if (cpci.config_public_charAdd(cpc) > 0)
            {
                return Content("<script>alert('添加成功！');location.href='/client/public_char';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败！');location.href='/client/public_char';</script>");
            }
        }
        //公共属性设置删除
        public ActionResult public_char_Delete(int id)
        {
            if (cpci.config_public_charDelete(new config_public_char { pbc_id = id }) > 0)
            {
                return Content("<script>alert('删除成功！');location.href='/client/public_char';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');location.href='/client/public_char';</script>");
            }
        }
        //职位分类设置页面
        public ActionResult config_major_kind()
        {
            ViewBag.list2 = cmki.config_major_kindCha();
            return View();
        }
        public ActionResult config_major_kindInsert()
        {
            config_major_kind cmk_Cha = cmki.config_major_kindCha().LastOrDefault();
            ViewBag.id= (Convert.ToInt32(cmk_Cha.major_kind_id) + 1);
            return View();
        }
        //职位分类设置添加
        public ActionResult config_major_kindInsert2(config_major_kind cmk)
        {
            if (cmki.config_major_kindInsert(cmk) > 0) 
            {
                return Content("<script>alert('添加成功！');location.href='/client/config_major_kind';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败！');location.href='/client/config_major_kind';</script>");
            }
        }
        //职位分类设置删除
        public ActionResult config_major_kindDelete(int id)
        {
            if (cmki.config_major_kindDel(new config_major_kind { mfk_id = id }) > 0) 
            {
                return Content("<script>alert('删除成功！');location.href='/client/config_major_kind';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');location.href='/client/config_major_kind';</script>");
            }
        }
        //职位设置
        public ActionResult config_major()
        {
            ViewBag.list3 = cmi.config_majorCha();
            return View();
        }
        public ActionResult config_majorInsert()
        {
            ViewBag.list4 = cmki.config_major_kindCha();//职业分类下拉列表
            config_major cm_Cha = cmi.config_majorCha().LastOrDefault() ;
            ViewBag.id2 = (Convert.ToInt32(cm_Cha.major_id) + 1);
            return View();
        }
        //职位设置添加
        public ActionResult config_majorInsert2(config_major cm)
        {
            cm.major_kind_name = cmki.config_major_kindChaID(c => c.major_kind_id.Equals(cm.major_kind_id)).FirstOrDefault().major_kind_name;//根据职位分类id查询name
            cm.test_amount = 0;
            if (cmi.config_majorAdd(cm) > 0)
            {
                return Content("<script>alert('添加成功！');location.href='/client/config_major';</script>");
            }
            else
            {
                return Content("<script>alert('添加失败！');location.href='/client/config_major';</script>");
            }
        }
        //职位设置删除
        public ActionResult config_majorDelete(int id)
        {
            if (cmi.config_majorDel(new config_major {  mak_id = id }) > 0)
            {
                return Content("<script>alert('删除成功！');location.href='/client/config_major';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');location.href='/client/config_major';</script>");
            }
        }
    }
}