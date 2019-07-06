using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBLL;
using locContaniner;
using Model;
using BLL;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Data.Entity;
using System.IO;

namespace UI.Controllers
{
    public class humanResourcesController : Controller
    {
        config_file_first_kindIBLL cffk = IocCreate.CreateProductTypeBLL<config_file_first_kindIBLL>("containerTwo", "config_file_first_kindServices");
        config_file_second_kindIBLL cfsk = IocCreate.CreateProductTypeBLL<config_file_second_kindIBLL>("containerTwo", "config_file_second_kindServices");
        config_file_third_kindIBLL cftk = IocCreate.CreateProductTypeBLL<config_file_third_kindIBLL>("containerTwo", "config_file_third_kindServices");
        config_majorIBLL cmi = IocCreate.CreateProductTypeBLL<config_majorIBLL>("containerTwo", "config_majorServices");
        config_major_kindIBLL cmk = IocCreate.CreateProductTypeBLL<config_major_kindIBLL>("containerTwo", "config_major_kindServices");
        engage_major_releaseIBLL emri = IocCreate.CreateProductTypeBLL<engage_major_releaseIBLL>("containerTwo", "engage_major_releaseServices");
        engage_resumeIBLL eri = IocCreate.CreateProductTypeBLL<engage_resumeIBLL>("containerTwo", "engage_resumeServices");
        config_public_charIBLL cpbb = IocCreate.CreateProductTypeBLL<config_public_charIBLL>("containerTwo", "config_public_charServices");
        engage_interviewIBLL eii = IocCreate.CreateProductTypeBLL<engage_interviewIBLL>("containerTwo", "engage_interviewServices");
        userIBLL ui = IocCreate.CreateProductTypeBLL<userIBLL>("containerTwo", "userServices");
        salary_standard_detailsIIBLL ssdi = IocCreate.CreateProductTypeBLL<salary_standard_detailsIIBLL>("containerTwo", "salary_standard_detailsServices");
        human_fileIBLL hfi = IocCreate.CreateProductTypeBLL<human_fileIBLL>("containerTwo", "human_fileServices");
        int pages = 0;//共多少页
        int rows = 0;//共有多少条记录
        public ActionResult human_register_index()
        {
            return View();
        }
        //人力资源档案登记分页查询
        public ActionResult human_register_index2(int CurrentPage)
        {
            List<engage_resume> list = eri.engage_releaseFY2(e => e.res_id, e => e.check_status_sx == 1 && e.Staff_files == 1 && e.pass_passComment == "通过" && e.Staff_files_dj == null, out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult human_register(int id)
        {
            res_idCha(id);
            show();
            NewMethod();
            return View();
        }
        //查询下拉框内容
        private void NewMethod()
        {
            ViewBag.config_public_char_list = cpbb.config_public_charIDcha(e => e.attribute_kind == "国籍");
            ViewBag.config_public_char_list2 = cpbb.config_public_charIDcha(e => e.attribute_kind == "民族");
            ViewBag.config_public_char_list3 = cpbb.config_public_charIDcha(e => e.attribute_kind == "宗教信仰");
            ViewBag.config_public_char_list4 = cpbb.config_public_charIDcha(e => e.attribute_kind == "政治面貌");
            ViewBag.config_public_char_list5 = cpbb.config_public_charIDcha(e => e.attribute_kind == "学历");
            ViewBag.config_public_char_list6 = cpbb.config_public_charIDcha(e => e.attribute_kind == "教育年限");
            ViewBag.config_public_char_list7 = cpbb.config_public_charIDcha(e => e.attribute_kind == "学历专业");
            ViewBag.config_public_char_list8 = cpbb.config_public_charIDcha(e => e.attribute_kind == "特长");
            ViewBag.config_public_char_list9 = cpbb.config_public_charIDcha(e => e.attribute_kind == "爱好");
        }

        private void res_idCha(int id)
        {
            engage_resume er = eri.engage_resumeXiuCha(e => e.res_id == id).FirstOrDefault();
            er.res_id = (short)id;
            ViewBag.engage_resume_list = er;
        }
        private void show()
        {
            ViewBag.list = cffk.config_file_first_kindCha();//一级机构下拉列表      
            ViewBag.list2 = cfsk.config_file_second_kindCha();//二级机构下拉列表    
            ViewBag.list3 = cftk.config_file_third_kindCha();//三级机构下拉列表 
            ViewBag.list4 = cmk.config_major_kindCha();//职业分类下拉列表
            ViewBag.list5 = cmi.config_majorCha();//职业名称下拉列表
            ViewBag.usercha = ui.userCha();//user表
            ViewBag.salary_standard_detailsCha = ssdi.salary_standard_detailsCha();//薪酬标准单详细信息
        }
        //根据获取的下拉列表id查询相关信息
        private void ChaID(human_file hf)
        {
            hf.first_kind_name = cffk.config_file_first_kindChaID(e => e.first_kind_id.Equals(hf.first_kind_id)).FirstOrDefault().first_kind_name;//根据一级机构id查询name
            hf.second_kind_name = cfsk.config_file_second_kindChaID(a => a.second_kind_id.Equals(hf.second_kind_id)).FirstOrDefault().second_kind_name;//根据二级机构id查询name
            hf.third_kind_name = cftk.config_file_third_kindChaID(b => b.third_kind_id.Equals(hf.third_kind_id)).FirstOrDefault().third_kind_name;//根据三级机构id查询name
            hf.human_major_kind_name = cmk.config_major_kindChaID(c => c.major_kind_id.Equals(hf.human_major_kind_id)).FirstOrDefault().major_kind_name;//根据职位分类id查询name
            hf.hunma_major_name = cmi.config_majorChaID(d => d.major_id.Equals(hf.human_major_id)).FirstOrDefault().major_name;//根据职位名称id查询name
            hf.salary_standard_name = ssdi.salary_standard_detailsXiuCha(f => f.standard_id.Equals(hf.salary_standard_id)).FirstOrDefault().standard_name;//薪酬标准单名称 
        }
        //人力资源档案登记添加
        public ActionResult human_fileInsert(human_file hf)
        {
            ChaID(hf);
            string CGnumber;//档案编号
            List<human_file> human_file_Cha = hfi.human_fileCha();
            engage_resume er = eri.engage_resumeXiuCha(e => e.res_id == hf.huf_id).FirstOrDefault();
            er.Staff_files_dj = 0;
            var start = DateTime.Now.ToString("yyyyMMdd");
            if (human_file_Cha.Count > 0)
            {
                int Count = human_file_Cha.Count;
                human_file hf_Count = human_file_Cha[Count - 1];
                int Number = Convert.ToInt32(hf_Count.human_id.Substring(hf_Count.human_id.Length - 1,1));
                Number++;
                CGnumber = "HF" + start + Number.ToString();
            }
            else
            {
                CGnumber = "HF" + start + "1";
            }
            hf.human_id = CGnumber;//生成的编号
            hf.check_status = 0;
            hf.delete_status = 0;
            if (eri.engage_resumeXiu(er) > 0)
            {
                if (hfi.human_fileAdd(hf) > 0)
                {
                    return Content("<script>location.href='/humanResources/register_choose_picture/?CGnumber="+CGnumber+"';</script>");
                }
                else
                {
                    return Content("<script>alert('提交失败！');location.href='/humanResources/human_register_index';</script>");
                }
            }
            return null;        
        }
        //图片上传
        public ActionResult register_choose_picture(string CGnumber)
        {
            ViewBag.CGid = CGnumber;
            return View();
        }
        [HttpPost]
        public ActionResult register_choose_picture2(HttpPostedFileBase file,string CGnumber)
        {
            human_file list = hfi.human_fileSelectCha(a => a.human_id == CGnumber).FirstOrDefault();
            if (file != null)
            {
                var fileName = file.FileName;
                var filePath = Server.MapPath(string.Format("~/{0}/", "images"));
                file.SaveAs(Path.Combine(filePath, fileName));
                list.human_picture = fileName;
            }
            list.human_file_status = true;

            if (hfi.human_fileXiu(list) > 0)
            {
                return Content("<script>alert('成功！');location.href='/humanResources/register_choose_picture/?CGnumber=" + CGnumber + "';</script>");
            }
            else
            {
                return Content("<script>alert('失败！');</script>");
            }
        }
        //文件上传
        public ActionResult register_choose_attachment(string CGnumber)
        {
            ViewBag.CGid = CGnumber;
            return View();
        }
        public ActionResult register_choose_attachment2(HttpPostedFileBase file, string CGnumber)
        {
            human_file list = hfi.human_fileSelectCha(a => a.human_id == CGnumber).FirstOrDefault();
            if (file != null)
            {
                var fileName = file.FileName;
                var filePath = Server.MapPath(string.Format("~/{0}/", "File"));
                file.SaveAs(Path.Combine(filePath, fileName));
                list.attachment_name = fileName;
            }
            list.human_file_status = true;
            if (hfi.human_fileXiu(list) > 0)
            {
                return Content("<script>alert('成功！');location.href='/humanResources/register_choose_attachment/?CGnumber=" + CGnumber + "';</script>");
            }
            else
            {
                return Content("<script>alert('失败！');</script>");
            }
        }
        //人力资源档案复核
        public ActionResult check_list()
        {
            return View();
        }
        public ActionResult check_list2(int CurrentPage)
        {
            List<human_file> list = hfi.human_fileFY(e => e.huf_id, e => e.check_status == 0, out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult human_check(int id)
        {
            human_file er = hfi.human_fileSelectCha(e => e.huf_id == id).FirstOrDefault();
            er.huf_id = (short)id;
            ViewBag.huf_id_list = er;
            NewMethod();
            show();
            ViewBag.usercha = ui.userCha();
            return View();
        }
        //人力资源档案登记复核修改操作
        public ActionResult human_checkUpdate(human_file hf_1)
        {
            hf_1.salary_standard_name = ssdi.salary_standard_detailsXiuCha(f => f.standard_id.Equals(hf_1.salary_standard_id)).FirstOrDefault().standard_name;//薪酬标准单名称 
            hf_1.human_file_status = false;
            hf_1.check_status = 1;
            if (hfi.human_fileXiu(hf_1) > 0) 
            {
                return Content("<script>location.href='/humanResources/register_choose_picture/?CGnumber=" + hf_1.human_id + "';</script>");
            }
            else
            {
                return Content("<script>alert('复核通过失败！');location.href='/humanResources/human_register_index';</script>");
            }
        }
        //人力资源档案查询
        public ActionResult query_locate()
        {
            show();
            return View();
        }
        public ActionResult query_list()
        {
            return View();
        }
        //人力资源档案查询分页
        public ActionResult query_list2(int CurrentPage)
        {
            return human_file_biao1(CurrentPage);
        }
        //查询分页
        private ActionResult human_file_biao1(int CurrentPage)
        {
            List<human_file> list;
            if (Session["where"] == null)
            {
                list = hfi.human_fileFY(e => e.huf_id, e => e.huf_id > 0, out rows, out pages, CurrentPage, 3);
            }
            else
            {
                Expression<Func<human_file, bool>> where = Session["where"] as Expression<Func<human_file, bool>>;
                list = hfi.human_fileFY(e => e.huf_id, where, out rows, out pages, CurrentPage, 3);
            }
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }

        //人力资源档案查询待条件分页
        public ActionResult query_list3(int CurrentPage, string yi, string er, string san, string zhiwei, string zhiwei_name, string start, string end)
        {
            return human_file_biao2(yi, er, san, zhiwei, zhiwei_name, start, end);
        }
        //带条件分页
        private ActionResult human_file_biao2(string yi, string er, string san, string zhiwei, string zhiwei_name, string start, string end)
        {
            DateTime k = Convert.ToDateTime(start);
            DateTime j = Convert.ToDateTime(end);
            //多条件查询拼接
            Expression<Func<human_file, bool>> where = null;
            where = e => e.first_kind_id.Contains(yi) && e.second_kind_id.Contains(er) && e.third_kind_id.Contains(san) && e.human_major_kind_id.Contains(zhiwei) && e.human_major_id.Contains(zhiwei_name) && e.regist_time > k && e.regist_time < j;
            //将条件保存到session
            Session["where"] = where;
            return Content("yes");
        }

        //人力资源档案查询根据编号查询内容
        public ActionResult quanery_list_IDcha(string id)
        {
            NewMethod1(id);
            return View();
        }
        //根据档案编号查询内容
        private void NewMethod1(string id)
        {
            human_file er = hfi.human_fileSelectCha(e => e.human_id == id).FirstOrDefault();
            ViewBag.huf_id_list2 = er;
        }

        //人力资源档案变更
        public ActionResult change_locate()
        {
            show();
            return View();
        }
        public ActionResult change_list()
        {
            return View();
        }
        public ActionResult change_list2(int CurrentPage)
        {
            return human_file_biao1(CurrentPage);
        }
        public ActionResult change_list3(int CurrentPage, string yi, string er, string san, string zhiwei, string zhiwei_name, string start, string end)
        {
            return human_file_biao2(yi, er, san, zhiwei, zhiwei_name, start, end);
        }
        public ActionResult change_list_information(string id)
        {
            NewMethod1(id);
            show();
            NewMethod();
            return View();
        }
        //人力资源档案删除
        public ActionResult delete_locate()
        {
            show();
            return View();
        }
        public ActionResult delete_list()
        {
            return View();
        }
        public ActionResult delete_list2(int CurrentPage)
        {
            List<human_file> list;
            if (Session["where"] == null)
            {
                list = hfi.human_fileFY(e => e.huf_id, e => e.delete_status == 0 || e.delete_status == null, out rows, out pages, CurrentPage, 3);
            }
            else
            {
                Expression<Func<human_file, bool>> where = Session["where"] as Expression<Func<human_file, bool>>;
                list = hfi.human_fileFY(e => e.huf_id, where, out rows, out pages, CurrentPage, 3);
            }
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult delete_list3(int CurrentPage, string yi, string er, string san, string zhiwei, string zhiwei_name, string start, string end)
        {

            DateTime k = Convert.ToDateTime(start);
            DateTime j = Convert.ToDateTime(end);
            //多条件查询拼接
            Expression<Func<human_file, bool>> where = null;
            where = e => e.first_kind_id.Contains(yi) && e.second_kind_id.Contains(er) && e.third_kind_id.Contains(san) && e.human_major_kind_id.Contains(zhiwei) && e.human_major_id.Contains(zhiwei_name) && e.regist_time > k && e.regist_time < j && e.delete_status == 0 || e.delete_status == null;
            //将条件保存到session
            Session["where"] = where;
            return Content("yes");
        }
        public ActionResult delete_list_information(string id)
        {
            NewMethod1(id);
            return View();
        }
        public ActionResult delete_list_informationUpdate(human_file hf_2)
        {
            hf_2.salary_standard_name = ssdi.salary_standard_detailsXiuCha(f => f.standard_id.Equals(hf_2.salary_standard_id)).FirstOrDefault().standard_name;//薪酬标准单名称 
            hf_2.human_file_status = false;
            hf_2.check_status = 1;
            hf_2.delete_status = 1;
            if (hfi.human_fileXiu(hf_2) > 0)
            {
                return Content("<script>alert('删除成功！');location.href='/humanResources/delete_list';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');location.href='/humanResources/delete_list';</script>");
            }
        }
        //人力资源档案永久删除
        public ActionResult delete_forever_list()
        {
            return View();
        }
        public ActionResult delete_forever_list2(int CurrentPage)
        {
            List<human_file> list = hfi.human_fileFY(e => e.huf_id, e => e.delete_status == 0, out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult delete_forever_listDelete(int id)
        {
            string sql = "delete from dbo.human_file where huf_id=" + id;
            if (hfi.human_fileDel2(sql) > 0) 
            {
                return Content("<script>alert('删除成功！');location.href='/humanResources/delete_forever_list';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');location.href='/humanResources/delete_forever_list';</script>");
            }
        }
        //人力资源档案恢复
        public ActionResult recovery_locate()
        {
            show();
            return View();
        }
        public ActionResult recovery_list()
        {
            return View();
        }
        public ActionResult recovery_list2(int CurrentPage)
        {
            List<human_file> list;
            if (Session["where"] == null)
            {
                list = hfi.human_fileFY(e => e.huf_id, e => e.delete_status == 1, out rows, out pages, CurrentPage, 3);
            }
            else
            {
                Expression<Func<human_file, bool>> where = Session["where"] as Expression<Func<human_file, bool>>;
                list = hfi.human_fileFY(e => e.huf_id, where, out rows, out pages, CurrentPage, 3);
            }
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult recovery_list3(int CurrentPage, string yi, string er, string san, string zhiwei, string zhiwei_name, string start, string end)
        {
            DateTime k = Convert.ToDateTime(start);
            DateTime j = Convert.ToDateTime(end);
            //多条件查询拼接
            Expression<Func<human_file, bool>> where = null;
            where = e => e.first_kind_id.Contains(yi) && e.second_kind_id.Contains(er) && e.third_kind_id.Contains(san) && e.human_major_kind_id.Contains(zhiwei) && e.human_major_id.Contains(zhiwei_name) && e.regist_time > k && e.regist_time < j && e.delete_status == 1;
            //将条件保存到session
            Session["where"] = where;
            return Content("yes");
        }
        public ActionResult recovery_list_information(string id)
        {
            NewMethod1(id);
            return View();
        }
        public ActionResult recovery_list_informationUpdate(human_file hf_3)
        {
            hf_3.salary_standard_name = ssdi.salary_standard_detailsXiuCha(f => f.standard_id.Equals(hf_3.salary_standard_id)).FirstOrDefault().standard_name;//薪酬标准单名称 
            hf_3.human_file_status = false;
            hf_3.check_status = 1;
            hf_3.delete_status = 0;
            if (hfi.human_fileXiu(hf_3) > 0)
            {
                return Content("<script>alert('恢复成功！');location.href='/humanResources/recovery_list';</script>");
            }
            else
            {
                return Content("<script>alert('恢复失败！');location.href='/humanResources/recovery_list';</script>");
            }
        }
    }
}