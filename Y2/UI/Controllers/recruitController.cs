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

namespace UI.Controllers
{
    public class recruitController : Controller
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
        int pages = 0;//共多少页
        int rows = 0;//共有多少条记录
        // GET: recruit
        public ActionResult position_register()
        {
            show();
            return View();
        }

        private void show()
        {
            ViewBag.list = cffk.config_file_first_kindCha();//一级机构下拉列表      
            ViewBag.list2 = cfsk.config_file_second_kindCha();//二级机构下拉列表    
            ViewBag.list3 = cftk.config_file_third_kindCha();//三级机构下拉列表 
            ViewBag.list4 = cmk.config_major_kindCha();//职业分类下拉列表
            ViewBag.list5 = cmi.config_majorCha();//职业名称下拉列表
            ViewBag.usercha = ui.userCha();//user表
        }
        [HttpPost]
        //根据一级机构查询二级下拉列表
        public ActionResult first_kind_id(string first_kind_id)
        {
            List<config_file_second_kind> list = cfsk.config_file_second_kindIDCha(e => e.first_kind_id == first_kind_id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        [HttpPost]
        //根据二级机构查询三级下拉列表
        public ActionResult second_kind_id(string second_kind_id)
        {
            List<config_file_third_kind> list = cftk.config_file_third_kindIDCha(e => e.second_kind_id == second_kind_id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        [HttpPost]
        //根据职位分类查询职位名称下拉列表
        public ActionResult major_kind_id(string major_kind_id)
        {
            List<config_major> list = cmi.config_majorIDCha(e => e.major_kind_id == major_kind_id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        //职位发布登记添加
        public ActionResult engage_major_releaseInsert(engage_major_release emr)
        {
            ChaID(emr);
            ViewBag.dt = emr.register;
            ViewBag.dt2 = emr.regist_time;
            if (emri.engage_major_releaseAdd(emr) > 0) //添加操作
            {
                return Content("<script>alert('发布登记成功！');location.href='/recruit/position_register';</script>");
            }
            else
            {
                return Content("<script>alert('发布登记失败！');location.href='/recruit/position_register';</script>");
            }
        }
        //根据获取的下拉列表id查询相关信息
        private void ChaID(engage_major_release emr)
        {
            emr.first_kind_name = cffk.config_file_first_kindChaID(e => e.first_kind_id.Equals(emr.first_kind_id)).FirstOrDefault().first_kind_name;//根据一级机构id查询name
            emr.second_kind_name = cfsk.config_file_second_kindChaID(a => a.second_kind_id.Equals(emr.second_kind_id)).FirstOrDefault().second_kind_name;//根据二级机构id查询name
            emr.third_kind_name = cftk.config_file_third_kindChaID(b => b.third_kind_id.Equals(emr.third_kind_id)).FirstOrDefault().third_kind_name;//根据三级机构id查询name
            emr.major_kind_name = cmk.config_major_kindChaID(c => c.major_kind_id.Equals(emr.major_kind_id)).FirstOrDefault().major_kind_name;//根据职位分类id查询name
            emr.major_name = cmi.config_majorChaID(d => d.major_id.Equals(emr.major_id)).FirstOrDefault().major_name;//根据职位名称id查询name
        }
        //职位发布变更
        [HttpGet]
        public ActionResult position_change_update()
        {
            return View();
        }
        //职位发布变更分页查询
        public ActionResult position_change_update2(int CurrentPage)
        {
            List<engage_major_release> list = emri.engage_major_releaseFY(e => e.mre_id, e => e.mre_id > 0, out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        //职位发布变更修改
        public ActionResult position_release_changeUpdate(engage_major_release emr)
        {
            ChaID(emr);
            if (emri.engage_major_releaseXiu(emr) > 0)
            {
                return Content("<script>alert('修改成功！');location.href='/recruit/position_change_update';</script>");
            }
            else
            {
                return Content("<script>alert('修改失败！');location.href='/recruit/position_change_update';</script>");
            }
        }
        //根据职位发布变更id查询简历信息
        [HttpGet]
        public ActionResult position_release_changeUpdateCha(int id)
        {
            IDcha(id);
            show();
            return View();
        }
        //根据id查询简历信息方法
        private void IDcha(int id)
        {
            engage_major_release list = emri.engage_major_releaseXiuCha(e => e.mre_id == id).FirstOrDefault();
            list.mre_id = (short)id;
            ViewBag.dt = list;
        }
        //职位发布变更删除
        public ActionResult position_registerDel(int id)
        {
            if (emri.engage_major_releaseDel(new engage_major_release() { mre_id = (short)id }) > 0)
            {
                return Content("<script>alert('删除成功！');location.href='/recruit/position_change_update';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');location.href='/recruit/position_change_update';</script>");
            }
        }
        //职位发布查询
        [HttpGet]
        public ActionResult position_release_search()
        {
            return View();
        }
        [HttpGet]
        //根据职位发布查询的id显示简历信息
        public ActionResult position_release_details(int id)
        {
            IDcha(id);
            return View();
        }
        //简历登记下拉列表
        [HttpPost]
        public ActionResult register(engage_major_release emr)
        {
            ChaID(emr);
            IDcha(emr.mre_id);
            ViewBag.list = cpbb.config_public_charIDcha(e => e.attribute_kind == "国籍");
            ViewBag.list2 = cpbb.config_public_charIDcha(e => e.attribute_kind == "民族");
            ViewBag.list3 = cpbb.config_public_charIDcha(e => e.attribute_kind == "宗教信仰");
            ViewBag.list4 = cpbb.config_public_charIDcha(e => e.attribute_kind == "政治面貌");
            ViewBag.list5 = cpbb.config_public_charIDcha(e => e.attribute_kind == "学历");
            ViewBag.list6 = cpbb.config_public_charIDcha(e => e.attribute_kind == "教育年限");
            ViewBag.list7 = cpbb.config_public_charIDcha(e => e.attribute_kind == "学历专业");
            ViewBag.list8 = cpbb.config_public_charIDcha(e => e.attribute_kind == "特长");
            ViewBag.list9 = cpbb.config_public_charIDcha(e => e.attribute_kind == "爱好");
            return View();
        }
        //简历登记添加
        [HttpPost]
        public ActionResult registerInsert(engage_resume er)
        {
            er.interview_status = 0;
            er.check_status = 0;
            er.check_status_sx = 0;
            er.human_major_kind_name = cmk.config_major_kindChaID(c => c.major_kind_id.Equals(er.human_major_kind_id)).FirstOrDefault().major_kind_name;//根据职位分类id查询name
            er.human_major_name = cmi.config_majorChaID(d => d.major_id.Equals(er.human_major_id)).FirstOrDefault().major_name;//根据职位名称id查询name
            if (eri.engage_resumeAdd(er) > 0)
            {
                return Content("<script>alert('操作成功!');location.href='/recruit/position_release_search';</script>");
            }
            else
            {
                return Content("<script>alert('操作失败!');location.href='/recruit/position_release_search';</script>");
            }
        }
        //简历筛选
        [HttpGet]
        public ActionResult resume_choose()
        {
            show();
            return View();
        }
        [HttpPost]
        public ActionResult resume_choose(string id)
        {
            List<config_major> list = cmi.config_majorChaID(e => e.major_kind_id == id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        [HttpGet]
        public ActionResult resume_list()
        {
            return View();
        }
        //简历筛选分页
        public ActionResult resume_list2(int CurrentPage)
        {
            List<engage_resume> list;
            if (Session["where"] == null)
            {
                list = eri.engage_releaseFY(e => e.res_id, e => e.check_status == 0, out rows, out pages, CurrentPage, 3);
            }
            else
            {
                Expression<Func<engage_resume, bool>> where = Session["where"] as Expression<Func<engage_resume, bool>>;
                list = eri.engage_releaseFY(e => e.res_id, where, out rows, out pages, CurrentPage, 3);
            }
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpPost]
        public ActionResult resume_list3(int CurrentPage, string gjz, string start, string end, string major_kind_id, string human_major_id)
        {
            DateTime k = Convert.ToDateTime(start);
            DateTime j = Convert.ToDateTime(end);
            //多条件查询拼接
            Expression<Func<engage_resume, bool>> where = null;
            where = e => (e.human_name.Contains(gjz) || e.human_telephone.Contains(gjz) || e.human_idcard.Contains(gjz) || e.human_history_records.Contains(gjz)) && e.human_major_kind_id.Contains(major_kind_id) && e.human_major_id.Contains(human_major_id) && e.regist_time > k && e.regist_time < j && e.check_status == 0;
            //将条件保存到session
            Session["where"] = where;
            return Content("yes");
        }
        public ActionResult resume_details(int id)
        {
            res_idCha(id);
            ViewBag.usercha = ui.userCha();
            return View();
        }
        //根据engage_resume表的主键查询
        private void res_idCha(int id)
        {
            engage_resume er = eri.engage_resumeXiuCha(e => e.res_id == id).FirstOrDefault();
            er.res_id = (short)id;
            ViewBag.list = er;
        }

        [HttpPost]
        //简历筛选编辑
        public ActionResult resume_detailsUpdate(engage_resume er)
        {
            er.interview_status = 0;
            er.check_status = 1;
            er.check_status_sx = 0;
            er.human_major_kind_name = cmk.config_major_kindChaID(c => c.major_kind_id.Equals(er.human_major_kind_id)).FirstOrDefault().major_kind_name;//根据职位分类id查询name
            er.human_major_name = cmi.config_majorChaID(d => d.major_id.Equals(er.human_major_id)).FirstOrDefault().major_name;//根据职位名称id查询name
            if (eri.engage_resumeXiu(er) > 0)
            {
                return Content("<script>alert('推荐成功！');location.href='/recruit/resume_list';</script>");
            }
            else
            {
                return Content("推荐失败！");
            }
        }
        [HttpGet]
        //有效简历查询
        public ActionResult valid_resume()
        {
            show();
            return View();
        }
        //根据职位分类查询出职位名称
        [HttpPost]
        public ActionResult valid_resume(string id)
        {
            List<config_major> list = cmi.config_majorChaID(e => e.major_kind_id == id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        [HttpGet]
        public ActionResult valid_list()
        {
            return View();
        }
        //有效简历不带条件查询
        public ActionResult valid_list2(int CurrentPage)
        {
            List<engage_resume> list;
            if (Session["where"] == null)
            {
                list = eri.engage_releaseFY(e => e.res_id, e => e.check_status == 1, out rows, out pages, CurrentPage, 3);
            }
            else
            {
                Expression<Func<engage_resume, bool>> where = Session["where"] as Expression<Func<engage_resume, bool>>;
                list = eri.engage_releaseFY(e => e.res_id, where, out rows, out pages, CurrentPage, 3);
            }
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        //有效简历带条件查询
        [HttpPost]
        public ActionResult valid_list3(int CurrentPage, string gjz, string start, string end, string major_kind_id, string human_major_id)
        {
            DateTime k = Convert.ToDateTime(start);
            DateTime j = Convert.ToDateTime(end);
            //多条件查询拼接
            Expression<Func<engage_resume, bool>> where = null;
            where = e => (e.human_name.Contains(gjz) || e.human_telephone.Contains(gjz) || e.human_idcard.Contains(gjz) || e.human_history_records.Contains(gjz)) && e.human_major_kind_id.Contains(major_kind_id) && e.human_major_id.Contains(human_major_id) && e.regist_time > k && e.regist_time < j && e.check_status == 1;
            //将条件保存到session
            Session["where"] = where;
            return Content("yes");
        }
        public ActionResult resume_select(int id)
        {
            res_idCha(id);
            return View();
        }
        //面试结果登记分页
        [HttpGet]
        public ActionResult interview_list()
        {
            return View();
        }             
        public ActionResult interview_list2(int CurrentPage)
        {
            List<engage_resume> list;
            if (Session["where"] == null)
            {
                list = eri.engage_releaseFY(e => e.res_id, e => e.interview_status == 0, out rows, out pages, CurrentPage, 3);
            }
            else
            {
                Expression<Func<engage_resume, bool>> where = Session["where"] as Expression<Func<engage_resume, bool>>;
                list = eri.engage_releaseFY(e => e.res_id, where, out rows, out pages, CurrentPage, 3);
            }
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        [HttpPost]
        public ActionResult interview_list3(int CurrentPage, string gjz, string start, string end, string major_kind_id, string human_major_id)
        {
            DateTime k = Convert.ToDateTime(start);
            DateTime j = Convert.ToDateTime(end);
            //多条件查询拼接
            Expression<Func<engage_resume, bool>> where = null;
            where = e => (e.human_name.Contains(gjz) || e.human_telephone.Contains(gjz) || e.human_idcard.Contains(gjz) || e.human_history_records.Contains(gjz)) && e.human_major_kind_id.Contains(major_kind_id) && e.human_major_id.Contains(human_major_id) && e.regist_time > k && e.regist_time < j && e.interview_status == 0;
            //将条件保存到session
            Session["where"] = where;
            return Content("yes");
        }
        [HttpGet]
        public ActionResult interview_resume()
        {
            show();
            return View();
        }
        [HttpPost]
        public ActionResult interview_resume(string id)
        {
            List<config_major> list = cmi.config_majorChaID(e => e.major_kind_id == id).ToList();
            return Content(JsonConvert.SerializeObject(list));
        }
        public ActionResult interview_register(int id)
        {
            ViewBag.list2 = eii.engage_interviewCha();
            ViewBag.list3 = eii.engage_interviewChaID(e => e.resume_id == id);
            res_idCha(id);
            return View();
        }
        [HttpPost]
        public ActionResult interview_registerInsert(engage_interview ei)
        {
            ei.interview_status = 1;
            ei.check_status = 0;
            ei.result = ei.interview_comment;
            //根据engage_interview表的简历编号查询engage_resume表信息
            engage_resume er = eri.engage_resumeXiuCha(e => e.res_id == ei.resume_id).FirstOrDefault();
            //修改engage_resume表的面试状态
            er.interview_status = 1;
            er.check_status_sx = 0;
            //查询一遍engage_interview表信息，看engage_interview表是否是空表
            engage_interview list = eii.engage_interviewCha().FirstOrDefault();
            //根据前台获取engage_resume表中的id去查engage_interview简历id，为了判断id是否相同。
            engage_interview PDcha = eii.engage_interviewChaID(e => e.resume_id == ei.resume_id).FirstOrDefault();
            //判断engage_interview是否有相同engage_interview简历编号
            if (list == null)
            {
                if(PDcha == null)//没查出来做添加
                {
                    if (eri.engage_resumeXiu(er) > 0)
                    {
                        if (eii.engage_interviewAdd(ei) > 0)
                        {
                            return Content("<script>alert('操作成功！');location.href='/recruit/interview_list';</script>");
                        }
                        else
                        {
                            return Content("<script>alert('操作失败！');location.href='/recruit/interview_list';</script>");
                        }
                    }
                    else
                    {
                        return Content("alert('修改面试状态失败！');location.href='/recruit/interview_list';");
                    }
                }
                else
                {
                    return Content("");
                }
            }
            else
            {               
                if (PDcha == null) 
                {
                    if (eri.engage_resumeXiu(er) > 0)
                    {
                        if (eii.engage_interviewAdd(ei) > 0)
                        {
                            return Content("<script>alert('操作成功！');location.href='/recruit/interview_list';</script>");
                        }
                        else
                        {
                            return Content("<script>alert('操作失败！');location.href='/recruit/interview_list';</script>");
                        }
                    }
                    else
                    {
                        return Content("alert('修改面试状态失败！');location.href='/recruit/interview_list';");
                    }
                }
                else
                {
                    ei.interview_amount++;
                    //判断engage_interview表简历编号是否与engage_resume表的id相同，如果相同则继续修改。
                    if (PDcha.resume_id == ei.resume_id)
                    {
                        eri.engage_resumeXiu(er);
                        if (eii.engage_interviewXiu(ei) > 0)
                        {
                            return Content("<script>alert('操作成功！');location.href='/recruit/interview_list';</script>");
                        }
                        else
                        {
                            return Content("<script>alert('操作失败！');location.href='/recruit/interview_list';</script>");
                        }
                    }
                    else
                    {
                        return Content("");
                    }
                }              
            }                
        }
        //面试筛选
        [HttpGet]
        public ActionResult sift_list()
        {
            return View();
        }
        public ActionResult sift_list2(int CurrentPage)
        {
            List<engage_interview> list = eii.engage_major_releaseFY(e => e.ein_id, e => e.check_status == 0, out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult interview_sift(int id)
        {
            ViewBag.list3 = eii.engage_interviewChaID(e => e.resume_id == id);
            res_idCha(id);
            return View();
        }
        [HttpPost]
        public ActionResult interview_siftUpdate(engage_interview eit)
        {                       
            eit.result = eit.interview_comment;
            engage_resume list = eri.engage_resumeXiuCha(e => e.res_id == eit.resume_id).FirstOrDefault();
            if(eit.check_comment == "建议面试")
            {
                list.interview_status = 0;
                list.checker = null;
                list.check_time = null;
                list.check_status = 0;
                list.recomandation = null;
                eit.interview_status = 0;
                eit.check_status = 1;
                if (eri.engage_resumeXiu(list) > 0)
                {
                    if (eii.engage_interviewXiu(eit) > 0)
                    {
                        return Content("<script>alert('建议面试成功！');location.href='/recruit/sift_list';</script>");
                    }
                    else
                    {
                        return Content("<script>alert('建议面试失败！');location.href='/recruit/sift_list';</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('修改简历表数据失败！');location.href='/recruit/sift_list';</script>");
                }
            }
            else if (eit.check_comment == "建议录用")
            {
                eit.interview_status = 1;
                eit.check_status = 1;
                list.check_status_sx = 1;
                eri.engage_resumeXiu(list);
                if (eii.engage_interviewXiu(eit) > 0)
                {
                    return Content("<script>alert('建议录用成功！');location.href='/recruit/sift_list';</script>");
                }
                else
                {
                    return Content("<script>alert('建议录用失败！');location.href='/recruit/sift_list';</script>");
                }
            }
            else if (eit.check_comment == "删除简历")
            {
                if (list.res_id == eit.resume_id) 
                {
                    if (eri.engage_resumeDel(list) > 0)
                    {
                        string sql = "delete from dbo.engage_interview where resume_id=" + eit.resume_id;
                        if (eii.engage_interviewDel(sql) > 0)
                        {
                            return Content("<script>alert('删除简历成功！');location.href='/recruit/sift_list';</script>");
                        }
                        else
                        {
                            return Content("<script>alert('删除简历失败！');location.href='/recruit/sift_list';</script>");
                        }
                    }
                    else
                    {
                        return Content("<script>alert('删除简历表失败！');location.href='/recruit/sift_list';</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('简历表id不与面试表简历编号相同无法删除！');location.href='/recruit/sift_list';</script>");
                }
            }
            return null;          
        }
        //录用申请
        [HttpGet]
        public ActionResult register_list()
        {
            return View();
        }
        public ActionResult register_list2(int CurrentPage)
        {
            List<engage_resume> list = eri.engage_releaseFY2(e => e.res_id, e => e.check_status_sx == 1 && e.Staff_files == null || e.Staff_files == 0 && e.pass_checkComment == "不通过", out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult register_ly(int id)
        {
            ViewBag.list3 = eii.engage_interviewChaID(e => e.resume_id == id);
            res_idCha(id);
            return View();
        }
        public ActionResult register_lyUpdate(engage_resume er_register_ly)
        {
            er_register_ly.check_status_sx = 1;
            er_register_ly.interview_status = 1;
            er_register_ly.check_status = 1;
            if (er_register_ly.pass_checkComment == "通过")
            {
                er_register_ly.Staff_files = 1;
                if (eri.engage_resumeXiu(er_register_ly) > 0)
                {
                    return Content("<script>alert('申请录用成功！');location.href='/recruit/register_list';</script>");
                }
                else
                {
                    return Content("<script>alert('申请录用失败！');location.href='/recruit/register_list';</script>");
                }
            }
            else if(er_register_ly.pass_checkComment == "不通过")
            {
                er_register_ly.Staff_files = 0;
                er_register_ly.interview_status = 0;
                if (eri.engage_resumeXiu(er_register_ly) > 0)
                {
                    return Content("<script>alert('释放简历成功！');location.href='/recruit/register_list';</script>");
                }
                else
                {
                    return Content("<script>alert('释放简历失败！');location.href='/recruit/register_list';</script>");
                }
            }
            return null;           
        }
        //录用审批
        public ActionResult check_list()
        {
            return View();
        }
        public ActionResult check_list2(int CurrentPage)
        {
            List<engage_resume> list = eri.engage_releaseFY2(e => e.res_id, e => e.check_status_sx == 1 && e.Staff_files == 1 && e.pass_passComment == null, out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult check(int id)
        {
            ViewBag.list3 = eii.engage_interviewChaID(e => e.resume_id == id);
            res_idCha(id);
            return View();
        }
        public ActionResult checkUpdate(engage_resume er_register_sp)
        {
            er_register_sp.check_status_sx = 1;
            er_register_sp.interview_status = 1;
            er_register_sp.check_status = 1;
            er_register_sp.Staff_files = 1;
            er_register_sp.pass_checkComment = "通过";
            if (er_register_sp.pass_passComment == "通过")
            {
                if (eri.engage_resumeXiu(er_register_sp) > 0)
                {
                    return Content("<script>alert('录用审批成功！');location.href='/recruit/check_list';</script>");
                }
                else
                {
                    return Content("<script>alert('录用审批失败！');location.href='/recruit/check_list';</script>");
                }
            }
            else if (er_register_sp.pass_passComment == "不通过")
            {
                if (eri.engage_resumeDel(er_register_sp) > 0)
                {
                    string sql = "delete from dbo.engage_interview where resume_id=" + er_register_sp.res_id;
                    if (eii.engage_interviewDel(sql) > 0)
                    {
                        return Content("<script>alert('删除成功！');location.href='/recruit/check_list';</script>");
                    }
                    else
                    {
                        return Content("<script>alert('删除面试表失败！');location.href='/recruit/check_list';</script>");
                    }
                }
                else
                {
                    return Content("<script>alert('删除简历表失败！');location.href='/recruit/check_list';</script>");
                }
            }
            return null;
        }
        //录用查询
        public ActionResult list()
        {
            return View();
        }
        public ActionResult list2(int CurrentPage)
        {
            List<engage_resume> list = eri.engage_releaseFY2(e => e.res_id, e => e.check_status_sx == 1 && e.Staff_files == 1 && e.pass_passComment == "通过", out rows, out pages, CurrentPage, 3);
            Dictionary<string, Object> di = new Dictionary<string, object>();
            di["dt"] = list;
            di["rows"] = rows;
            di["pages"] = pages;
            return Content(JsonConvert.SerializeObject(di));
        }
        public ActionResult details(int id)
        {
            ViewBag.list3 = eii.engage_interviewChaID(e => e.resume_id == id);
            res_idCha(id);
            return View();
        }
    }
}