using CodeGenerator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CodeGenerator.Web.Controllers
{
    public class CodeGeneratorController : Controller
    {
        // GET: CodeGenerator
        public ActionResult Index()
        {
            return View();
        }

        //代码入库
        [HttpGet]
        public ActionResult CodeAdd()
        {
            using (var db=new CGDataBase())
            {
                var list= db.type.Where(t => true).ToList();
                var selectListItems = new List<SelectListItem>()
                {
                    new SelectListItem(){Value="0",Text="请选择",Selected=true },
                };
                var typelist = new SelectList(list, "t_id", "t_title");
                selectListItems.AddRange(typelist);
                ViewBag.database = selectListItems;
            }
                return View();
        }
        [HttpPost]
        public ActionResult CodeAdd(int type,string htmlDesc,int nid)
        {
            for(int i = 1; i <= nid; i++)
            {
                string a = Request.Form["method"+i];
            }
            
            return View();
        }

        //添加类别
        [HttpGet]
        public ActionResult TypeAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TypeAdd(string t_type)
        {
            
            if (!string.IsNullOrWhiteSpace(t_type))
            {
                //返回json对象
                //var result = new List<object>();
                //result.Add(new
                //{
                //    msg = "ok",
                //    code = 1
                //});
                //return Json(new { code = 200, msg = "ok" }, JsonRequestBehavior.AllowGet);
                //弹窗
                //return Content("<script>alert('请输入标题');history.go(-1);</script>");
                using (var db=new CGDataBase())
                {
                    type t = new type()
                    {
                        t_title = t_type
                    };
                    db.type.Add(t);
                    if (db.SaveChanges() > 0)
                    {
                        return Json(new { code = 1, msg = "添加控件类别成功！" });
                    }
                    else
                    {
                        return Json(new { code = 0, msg = "添加控件类别失败！" });
                    }
                }
            }
            else
            {
                return Json(new { code = 101, msg = "参数错误" },JsonRequestBehavior.AllowGet);
            }
        }
    }
}