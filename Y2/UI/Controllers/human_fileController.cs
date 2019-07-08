﻿using BLL;
using BAL;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;

namespace UI.Controllers
{
    public class human_fileController : Controller
    {
        human_fileServices hb = new human_fileServices();
        HR_DBEntities hd = new HR_DBEntities();
        // GET: human_file
        public ActionResult Index()
        {
            return View();
        }

        //查询全部
        public ActionResult Index2()
        {
            var dt = hb.SelectAll<config_file_first_kind>();
            return Content(JsonConvert.SerializeObject(dt));
        }


        //查询二级菜单
        public ActionResult Index3(string id)
        {
         var dt = hb.SelectWhere(e=>e.first_kind_id==id);
            return Content(JsonConvert.SerializeObject(dt));
        }
        //查询三级菜单
        public ActionResult Index4()
        {
            string sid=  Request["sid"];
            string fid = Request["fid"];
            var dt = hd.Set<config_file_third_kind>().Where(e=>e.first_kind_id==fid&&e.second_kind_id==sid).Select(e => e).ToList();
            return Content(JsonConvert.SerializeObject(dt));
        }

        //查询分类
        public ActionResult Index5()
        {
            string sql = "select * from dbo.human_file";
            var dt= DBhelper.Select(sql,"");
            return Content(JsonConvert.SerializeObject(dt));
        }

        //查询分类
        public ActionResult Index6()
        {
            string qid = Request["qid"];
            string sql = string.Format("select * from dbo.human_file where human_major_kind_id='{0}'", qid);
            var dt = DBhelper.Select(sql, "");
            return Content(JsonConvert.SerializeObject(dt));
        }



    }
}