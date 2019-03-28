using CodeGenerator.Common;
using CodeGenerator.Entity.POCOModel;
using CodeGenerator.Entity.ViewModel;
using CodeGenerator.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Business
{
    
    public class CodeInDataBase
    {
        public int AddCodeInBase(RequestFormInfo formInfo,List<definition> bllist, List<components> kjlist, List<data> qjlist, List<@default> mrlist, List<computed> jssxlist, List<methods> fflist)
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
                            desc = formInfo.htmlDesc
                        };
                        db.control.Add(controlBase);
                        int res = db.SaveChanges();
                        if (res > 0)
                        {
                            c_ID = controlBase.id;
                        }
                        //添加样式
                        style styleBase = new style()
                        {
                            content_css = StringDispose.AESEncrypt(formInfo.stylecss),
                            c_id = c_ID
                        };
                        db.style.Add(styleBase);
                        db.SaveChanges();

                        //添加自定义变量
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
                        //添加控件部件
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
                        //添加全局变量
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
                        //添加默认数据
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
                        //添加计算属性
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
                        //添加控件方法
                        if (fflist.Count > 0)
                        {
                            foreach(methods list in fflist)
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
                        //添加到PageShow页面
                        pageshow pageshow = new pageshow()
                        {
                            p_title = formInfo.PageDesc,
                            c_id = c_ID,
                            t_id = formInfo.type
                        };
                        db.pageshow.Add(pageshow);
                        if (db.SaveChanges() > 0)
                        {
                            transaction.Commit();
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
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
    }
}
