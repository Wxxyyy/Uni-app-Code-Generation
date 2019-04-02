using CodeGenerator.Business;
using CodeGenerator.Entity.POCOModel;
using CodeGenerator.Entity.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CodeGenerator.Web.Controllers
{
    public class CodeGeneratorController : Controller
    {
        // GET: CodeGenerator
        public ActionResult Index()
        {
            //然后下拉列表数据
            TypeInfo typeInfo = new TypeInfo();
            List<type> list = typeInfo.SelectAllInfo();
            var selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="0",Text="请选择",Selected=true },
            };
            var typelist = new SelectList(list, "t_id", "t_title");
            selectListItems.AddRange(typelist);
            ViewBag.database = selectListItems;
            return View();
        }
        [HttpPost]
        public ActionResult Index(int limit, int offset,int typeid)
        {
            CodeDataBase codeDataBase = new CodeDataBase();
            var result= codeDataBase.GetDataBase(limit, offset,typeid);
            //var rows = data.Skip(offset).Take(limit).ToList();
            return Json(result.Data);
        }

        //代码入库
        [HttpGet]
        public ActionResult CodeAdd()
        {
            //然后下拉列表数据
            TypeInfo typeInfo = new TypeInfo();
            List<type> list= typeInfo.SelectAllInfo();
            var selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){Value="0",Text="请选择",Selected=true },
            };
            var typelist = new SelectList(list, "t_id", "t_title");
            selectListItems.AddRange(typelist);
            ViewBag.database = selectListItems;

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CodeAdd(RequestFormInfo formInfo,int bl,int kj,int qj,int mr,int jssx,int ff)
        {
            //遍历自定义变量并放入集合
            List<definition> bianlianglist = new List<definition>();
            for (int i = 1; i <= bl; i++)
            {
                string desc = Request.Form["bldesc" + i];
                string content = Request.Form["bl" + i];
                if (!string.IsNullOrWhiteSpace(desc)&&!string.IsNullOrWhiteSpace(content))
                {
                    definition definition = new definition()
                    {
                        desc = desc,
                        content = content
                    };
                    bianlianglist.Add(definition);
                }
                
            }

            //遍历控件部件并放入集合
            List<components> kongjianList = new List<components>();
            for (int i = 1; i <= kj; i++)
            {
                string desc = Request.Form["kjdesc" + i];
                string content = Request.Form["kj" + i];
                if (!string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(content))
                {
                    components components = new components()
                    {
                        desc = desc,
                        content = content
                    };
                    kongjianList.Add(components);
                }
            }

            //遍历全局变量并放入集合
            List<data> quanjuList = new List<data>();
            for (int i = 1; i <= qj; i++)
            {
                string content = Request.Form["qjdesc" + i];
                string desc = Request.Form["qj" + i];
                if (!string.IsNullOrWhiteSpace(content) && !string.IsNullOrWhiteSpace(desc))
                {
                    data data = new data()
                    {
                        content = content,
                        desc = desc
                    };
                    quanjuList.Add(data);
                }

            }

            //遍历默认数据并放入集合
            List<@default> morenList = new List<@default>();
            for (int i = 1; i <= mr; i++)
            {
                string desc = Request.Form["mrdesc" + i];
                string key = Request.Form["mrkey" + i];
                string value = Request.Form["mrvalue" + i];
                if (!string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                {
                    @default @default = new @default()
                    {
                        desc = desc,
                        key = key,
                        value = value
                    };
                    morenList.Add(@default);
                }

            }

            //遍历计算属性并放入集合
            List<computed> jssxList = new List<computed>();
            for (int i = 1; i <= jssx; i++)
            {
                string jssxname = Request.Form["jssxname" + i];
                string jssxdesc = Request.Form["jssxdesc" + i];
                string jssxff = Request.Form["jssxff" + i];
                if (!string.IsNullOrWhiteSpace(jssxname) && !string.IsNullOrWhiteSpace(jssxdesc) && !string.IsNullOrWhiteSpace(jssxff))
                {
                    computed computed = new computed()
                    {
                        desc = jssxdesc,
                        name = jssxname,
                        content = jssxff
                    };
                    jssxList.Add(computed);
                }
            }

            //遍历控件方法并放入集合
            List<rests> qtfangfaList = new List<rests>();
            for (int i = 1; i <= ff; i++)
            {
                string qtffname = Request.Form["qtffname" + i];
                string qtffdesc = Request.Form["qtffdesc" + i];
                string qtffti = Request.Form["qtffti" + i];
                if (!string.IsNullOrWhiteSpace(qtffname) && !string.IsNullOrWhiteSpace(qtffdesc) && !string.IsNullOrWhiteSpace(qtffti))
                {
                    rests rests = new rests()
                    {
                        name = qtffname,
                        desc = qtffdesc,
                        content = qtffti
                    };
                    qtfangfaList.Add(rests);
                }
            }

            //遍历控件方法并放入集合
            List<methods> fangfaList = new List<methods>();
            for (int i = 1; i <= ff; i++)
            {
                string ffname = Request.Form["ffname" + i];
                string ffdesc = Request.Form["ffdesc" + i];
                string ffti = Request.Form["ffti" + i];
                if (!string.IsNullOrWhiteSpace(ffname) && !string.IsNullOrWhiteSpace(ffdesc) && !string.IsNullOrWhiteSpace(ffti))
                {
                    methods methods = new methods()
                    {
                        name = ffname,
                        desc = ffdesc,
                        content = ffti
                    };
                    fangfaList.Add(methods);
                }
            }


            //调用方法开始进行数据库存储
            //实例化代码入库类
            CodeDataBase codeInDataBase = new CodeDataBase();
            int result= codeInDataBase.AddCodeInBase(formInfo,bianlianglist,kongjianList,quanjuList,morenList,jssxList, qtfangfaList, fangfaList);
            switch (result)
            {
                case 0:
                    return Json(new { code = 1, msg = "代码入库失败！" }, JsonRequestBehavior.AllowGet);
                case 1:
                    return Json(new { code = 1, msg = "代码入库成功！" }, JsonRequestBehavior.AllowGet);
                case 2:
                    return Json(new { code = 1, msg = "html代码入库失败！" }, JsonRequestBehavior.AllowGet);
                case 3:
                    return Json(new { code = 1, msg = "Css样式入库失败！" }, JsonRequestBehavior.AllowGet);
                case 4:
                    return Json(new { code = 1, msg = "自定义变量入库失败！" }, JsonRequestBehavior.AllowGet);
                case 5:
                    return Json(new { code = 1, msg = "控件部件入库失败！" }, JsonRequestBehavior.AllowGet);
                case 6:
                    return Json(new { code = 1, msg = "全局变量入库失败！" }, JsonRequestBehavior.AllowGet);
                case 7:
                    return Json(new { code = 1, msg = "默认数据入库失败！" }, JsonRequestBehavior.AllowGet);
                case 8:
                    return Json(new { code = 1, msg = "计算属性入库失败！" }, JsonRequestBehavior.AllowGet);
                case 9:
                    return Json(new { code = 1, msg = "控件方法入库失败！" }, JsonRequestBehavior.AllowGet);
                case 10:
                    return Json(new { code = 1, msg = "添加到PageShow页面失败！" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult TypeAdd(string t_title)
        {
            
            if (!string.IsNullOrWhiteSpace(t_title))
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
                TypeInfo typeInfo = new TypeInfo();
                if (typeInfo.AddTypeInfo(t_title))
                {
                    return Json(new { code = 1, msg = "添加类别成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { code = 0, msg = "添加类别失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { code = 101, msg = "参数错误" },JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 修改样式信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StyleEdit(int htmlid)
        {
            //int htmlid = int.Parse(Request.Form["htmlID"]);
            CodeDataBase codeData = new CodeDataBase();
            var result = codeData.GetStyle(htmlid);
            ViewBag.sid = ((style)result.Data).id;
            ViewBag.cid = htmlid;
            ViewBag.style =((style)result.Data).content_css;
            return View();
        }
        
        [HttpPost]
        public ActionResult StyleEdit(int cid,int sid,string stylecss,string type)
        {
            CodeDataBase codeData = new CodeDataBase();
            if (type == "add")
            {
                var result = codeData.AddFistStyleCss(cid, stylecss);
                return Json(new { code = result.ResultStatus, msg = result.Message });
            }else if (type == "update")
            {
                var result = codeData.EditStyCss(sid, stylecss);
                return Json(new { code = result.ResultStatus, msg = result.Message });
            }
            return View();
        }

        [HttpGet]
        public ActionResult DefinitionEdit(int htmlID)
        {
            CodeDataBase codeData = new CodeDataBase();
            var result = codeData.GetAllDefinition(htmlID);
            ViewBag.definitionlist = result.Data;
            return View();
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult update(string type,RequestFormInfo formInfo)
        {
            switch (type)
            {
                case "html":
                    CodeDataBase codeData = new CodeDataBase();
                    var result= codeData.updateHtml(formInfo);
                    return Json(new { code = result.ResultStatus, msg = result.Message }, JsonRequestBehavior.AllowGet);
                case "":
                    return View();
            }
            return View();
        }

    }
}