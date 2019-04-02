using CodeGenerator.Common;
using CodeGenerator.Entity.POCOModel;
using CodeGenerator.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Business
{
    
    public class CodeDataBase
    {
        /// <summary>
        /// 代码入库将数据添加到各个表中
        /// </summary>
        /// <param name="formInfo"></param>
        /// <param name="bllist"></param>
        /// <param name="kjlist"></param>
        /// <param name="qjlist"></param>
        /// <param name="mrlist"></param>
        /// <param name="jssxlist"></param>
        /// <param name="fflist"></param>
        /// <returns></returns>
        public int AddCodeInBase(RequestFormInfo formInfo,List<definition> bllist, List<components> kjlist, List<data> qjlist, List<@default> mrlist, List<computed> jssxlist,List<rests> qtfflist,List<methods> fflist)
        {
            //数据库上下文
            using (CGDataBase db = new CGDataBase())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int c_ID = 0;
                        //添加control表数据
                        control controlBase = new control()
                        {
                            name = formInfo.htmlName,
                            content = StringDispose.AESEncrypt(formInfo.htmlValue),
                            desc = formInfo.htmlDesc,
                            t_id=formInfo.type
                        };
                        db.control.Add(controlBase);
                        int res = db.SaveChanges();
                        if (res > 0)
                        {
                            c_ID = controlBase.id;
                        }
                        //添加样式（style）
                        if (!string.IsNullOrWhiteSpace(formInfo.stylecss))
                        {
                            style styleBase = new style()
                            {
                                content_css = StringDispose.AESEncrypt(formInfo.stylecss),
                                c_id = c_ID
                            };
                            db.style.Add(styleBase);
                            db.SaveChanges();
                        }

                        //添加自定义变量 (definition)
                        if (bllist.Count > 0)
                        {
                            foreach (definition list in bllist)
                            {
                                jb_definition definition = new jb_definition()
                                {
                                    content = StringDispose.AESEncrypt(list.content),
                                    desc = list.desc,
                                    c_id=c_ID
                                };
                                db.jb_definition.Add(definition);
                            }
                            db.SaveChanges();
                        }
                        //添加控件部件(components)
                        if (kjlist.Count > 0)
                        {
                            foreach(components list in kjlist)
                            {
                                jb_components components = new jb_components()
                                {
                                    content = StringDispose.AESEncrypt(list.content),
                                    desc = list.desc,
                                    c_id = c_ID
                                };
                                db.jb_components.Add(components);
                            }
                            db.SaveChanges();
                        }
                        //添加全局变量(data)
                        if (qjlist.Count > 0)
                        {
                            foreach(data list in qjlist)
                            {
                                jb_data data = new jb_data()
                                {
                                    content = StringDispose.AESEncrypt(list.content),
                                    desc = list.desc,
                                    c_id = c_ID
                                };
                                db.jb_data.Add(data);
                            }
                            db.SaveChanges();
                        }
                        //添加默认数据 (default)
                        if (mrlist.Count > 0)
                        {
                            foreach(@default list in mrlist)
                            {
                                jb_default @default = new jb_default()
                                {
                                    key = StringDispose.AESEncrypt(list.key),
                                    value = StringDispose.AESEncrypt(list.value),
                                    desc = list.desc,
                                    c_id = c_ID
                                };
                                db.jb_default.Add(@default);
                            }
                            db.SaveChanges();
                        }
                        //添加计算属性 (computed)
                        if (jssxlist.Count > 0)
                        {
                            foreach(computed list in jssxlist)
                            {
                                jb_computed computed = new jb_computed()
                                {
                                    name = list.name,
                                    content = StringDispose.AESEncrypt(list.content),
                                    desc = list.desc,
                                    c_id = c_ID
                                };
                                db.jb_computed.Add(computed);
                            }
                            db.SaveChanges();
                        }
                        //添加其他方法
                        if (qtfflist.Count > 0)
                        {
                            foreach (rests list in qtfflist)
                            {
                                jb_rests rests = new jb_rests()
                                {
                                    name = list.name,
                                    content = StringDispose.AESEncrypt(list.content),
                                    desc = list.desc,
                                    c_id = c_ID
                                };
                                db.jb_rests.Add(rests);
                            }
                            db.SaveChanges();
                        }
                        //添加控件方法 (methods)
                        if (fflist.Count > 0)
                        {
                            foreach (methods list in fflist)
                            {
                                jb_methods methods = new jb_methods()
                                {
                                    name = list.name,
                                    content = StringDispose.AESEncrypt(list.content),
                                    desc = list.desc,
                                    c_id = c_ID
                                };
                                db.jb_methods.Add(methods);
                            }
                            db.SaveChanges();
                        }
                        transaction.Commit();
                        return 1;
                        ////添加到PageShow页面
                        //pageshow pageshow = new pageshow()
                        //{
                        //    p_title = formInfo.PageDesc,
                        //    c_id = c_ID,
                        //    t_id = formInfo.type
                        //};
                        //db.pageshow.Add(pageshow);
                        //if (db.SaveChanges() > 0)
                        //{
                        //    transaction.Commit();
                        //    return 1;
                        //}
                        //else
                        //{
                        //    return 0;
                        //}
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }
        
        /// <summary>
        /// 获取代码入库的信息
        /// </summary>
        public OperateResult GetDataBase(int limit, int offset,int typeid)
        {   
            var db = new CGDataBase();
            db.Configuration.ProxyCreationEnabled = false;
            var query = db.control.AsQueryable();
            if (typeid > 0)
            {
                query = query.Where(s => s.t_id == typeid);
            }
            var list = query.OrderBy(c => c.id).Skip(offset).Take(limit).ToList();
            List<control> conlist = new List<control>();
            if (list != null)
            {
                foreach (var info in list)
                {
                    control control = new control()
                    {
                        id = info.id,
                        name = info.name,
                        desc = info.desc,
                        content = StringDispose.AESDecrypt(info.content),
                        t_id = info.t_id
                    };
                    conlist.Add(control);
                }
            }
            var retData = new { total = query.Count(), rows = conlist };
            return new OperateResult(ResultStatus.Success, "", retData);
        }

        /// <summary>
        /// 修改HTML信息
        /// </summary>
        /// <param name="formInfo"></param>
        /// <returns></returns>
        public OperateResult updateHtml(RequestFormInfo formInfo)
        {
            using (var db=new CGDataBase())
            {
                var htmlInfo= db.control.Where(c => c.id == formInfo.htmlID).FirstOrDefault();
                if (htmlInfo != null)
                {
                    htmlInfo.name = formInfo.htmlName;
                    htmlInfo.desc = formInfo.htmlDesc;
                    htmlInfo.content = StringDispose.AESEncrypt(formInfo.htmlValue);
                }
                if (db.SaveChanges() > 0)
                {
                    return new OperateResult(ResultStatus.Success, "修改Html信息成功！");
                }
                else
                {
                    return new OperateResult(ResultStatus.Error, "修改Html信息失败！");
                }
            }
        }
        /// <summary>
        /// 获取样式表信息
        /// </summary>
        /// <returns></returns>
        public OperateResult GetStyle(int htmlID)
        {
            using (var db=new CGDataBase())
            {
                var list = db.style.Where(s => s.c_id == htmlID).FirstOrDefault();
                style style=null;
                if (list != null)
                {
                    style = new style()
                    {
                        id = list.id,
                        c_id = list.c_id,
                        content_css = StringDispose.AESDecrypt(list.content_css)
                    };
                }
                else
                {
                    style = new style()
                    {
                        id = 0,
                        c_id = 0,
                        content_css = "未查询到样式信息！"
                    };
                }
                return new OperateResult(ResultStatus.Success, "ok", style);
            }
        }

        /// <summary>
        /// 单独添加一条css样式
        /// </summary>
        /// <returns></returns>
        public OperateResult AddFistStyleCss(int cid,string styCss)
        {
            //先检测此控件是否已有样式
            using (var db=new CGDataBase())
            {
                var list = db.style.Where(s => s.c_id == cid).FirstOrDefault();
                if (list == null)
                {
                    style style = new style()
                    {
                        c_id = cid,
                        content_css = StringDispose.AESEncrypt(styCss)
                    };
                    db.style.Add(style);
                    if (db.SaveChanges() > 0)
                    {
                        return new OperateResult(ResultStatus.Success, "添加样式成功！");
                    }
                }
                return new OperateResult(ResultStatus.Error, "错误，此控件已有样式！");
            }
        }
        /// <summary>
        /// 修改样式信息
        /// </summary>
        /// <returns></returns>
        public OperateResult EditStyCss(int sid, string styCss)
        {
            using (var db=new CGDataBase())
            {
               var list= db.style.Where(s => s.id == sid).FirstOrDefault();
                if (list != null)
                {
                    list.content_css = StringDispose.AESEncrypt(styCss);
                    if (db.SaveChanges() > 0)
                    {
                        return new OperateResult(ResultStatus.Success, "修改控件样式成功！");
                    }
                    else
                    {
                        return new OperateResult(ResultStatus.Error, "修改控件样式失败！");
                    }
                }
                return new OperateResult(ResultStatus.Error, "未查询到此控件的样式信息！");
                
            }
        }
        /// <summary>
        /// 获取所有Definition信息
        /// </summary>
        /// <returns></returns>
        public OperateResult GetAllDefinition(int cid)
        {
            using (var db=new CGDataBase())
            {
                var list = db.jb_definition.Where(jd => jd.c_id == cid).ToList();
                if (list != null)
                {
                    List<definition> definitionList = new List<definition>();
                    foreach(var item in list)
                    {
                        definition definition = new definition()
                        {
                            id = item.id,
                            desc = item.desc,
                            content = StringDispose.AESDecrypt(item.content),
                            c_id = cid
                        };
                        definitionList.Add(definition);
                    }
                    return new OperateResult(ResultStatus.Success, "", definitionList);
                }
                return new OperateResult(ResultStatus.Error, "错误,找不到数据");
            }
        }

    }
}
