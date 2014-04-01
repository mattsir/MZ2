using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.OleDb;
using System.Web;
using System.IO;
using System.Xml;

namespace BLL
{
    public class ContentObj
    {
        public OleHelper obj = new OleHelper();

        /// <summary>
        /// 判断管理员是否登录
        /// </summary>
        /// <returns></returns>
        public bool CheckAdmin()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["marsz"];
            if (cookie == null)
            {
                return false;  //用户未登录
            }
            else
            {
                return true;
            }
        }

        
        #region 文章内容列表
        /// <summary>
        /// 文章内容文章
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="PageItem"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable ContentPage(int CurrentPage, int PageItem, int id)
        {
            string boardstring;
            if (id == 0)
            { boardstring = ""; }
            else
            { boardstring = " And boardid=" + id; }
            string sql = "SELECT *,(Select boardname From mz_board Where mz_board.id=mz_Content.boardid) As boardname  From mz_Content Where flag=false " + boardstring + " Order by addtime desc";
            return obj.Query(sql, CurrentPage, PageItem, "mz_Content");
        }

        public DataTable ContentPage(int CurrentPage, int PageItem, int id, string desc)
        {
            string sql = "SELECT Title,Cover,Addtime From mz_Content Where flag=false Order by addtime";
            return obj.Query(sql);
        }

        public DataSet ContentPageds()
        {
            string sql = "SELECT Title,Cover,Addtime From mz_Content Where flag=false Order by addtime";
            return obj.QueryDs(sql);
        }
        #endregion

        public DataTable ContentTopByCate(int cateid)
        {
            string sql = "Select Top 1 * From mz_Content Where flag=false And boardid=" + cateid+" Order By id desc";
            DataTable dt = obj.Query(sql);
            return dt;
        }

        #region 获取文章总数
        public int ContentTotal(int id)
        {
            string boardstring;
            if (id == 0)
            { boardstring = ""; }
            else
            {boardstring=" And boardid=" + id;}
            string sql = "Select Count(*) From mz_Content Where flag=false " + boardstring + "";
            return Convert.ToInt32(obj.Scalar(sql));
        }
        #endregion

        #region 读取文章详情
        /// <summary>
        /// 读取文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public sModal.sContent GetContent(int id)
        {
            string sql = "Select * From mz_Content Where id=" + id;
            DataTable dt = obj.Query(sql);
            if (dt.Rows.Count > 0)
            {
                sModal.sContent scon = new sModal.sContent();
                scon.id = id;
                scon.title = dt.Rows[0]["title"].ToString();
                scon.boardid = Convert.ToInt32(dt.Rows[0]["boardid"].ToString());
                scon.content = dt.Rows[0]["content"].ToString();
                scon.summary = dt.Rows[0]["summary"].ToString();
                scon.addtime = dt.Rows[0]["addtime"].ToString();
                scon.url = dt.Rows[0]["url"].ToString();
                scon.tags = dt.Rows[0]["tags"].ToString();
                scon.pv = Convert.ToInt32(dt.Rows[0]["pv"].ToString());
                scon.cover = dt.Rows[0]["cover"].ToString();
                scon.flag = dt.Rows[0]["flag"].ToString();
                return scon;
            }
            else
            {
                return null;
            }
        }
        #endregion

        public DataTable GetContentListBytag(string tag)
        {
            string[] taglist = tag.Split(',');
            StringBuilder sp = new StringBuilder();
            foreach (string arrs in taglist)
            {
                if (sp.ToString() == "")
                {
                    sp.Append(" tags like '%" + arrs + "%'");
                }
                else
                {
                    sp.Append(" Or tags like '%" + arrs + "%'");
                }
            }
            string sql = "Select Top 5 * From mz_Content Where 1=1 Or (" + sp.ToString() + ") order by id desc";
            DataTable dt = obj.Query(sql);
            return dt;
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="content"></param>
        public void ContentUpdate(sModal.sContent content)
        {
            //string id;
            //if (content.id == 0)
            //{
            //    string sql = "Insert Into mz_Content (title,boardid,content,summary,tags,cover)" +
            //        " Values('" + content.title + "'," + content.boardid + ",'" + content.content + "','" + content.summary + "','" + content.tags + "','" + content.cover + "')";
            //    obj.Execute(sql);
            //    //string idsql = "Select top 1 id From mz_Content Order by id desc";
            //    //DataTable dt = obj.Query(idsql);
            //    //id = dt.Rows[0]["id"].ToString();
            //}
            //else
            //{
            //    string sql = "Update mz_Content Set title='" + content.title + "',boardid=" + content.boardid + ",content='" + content.content + "',summary='" + content.summary + "',tags='" + content.tags + "',cover='" + content.cover + "' where id=" + content.id;
            //    obj.Execute(sql);
            //    id = content.id.ToString();
            //}
            CreateXml(content);
            UpdateXmlList(content);
        }

        /// <summary>
        /// 更新list xml
        /// </summary>
        /// <param name="content"></param>
        public void UpdateXmlList(sModal.sContent content)
        {
            //DataTable dt = ContentPage(1, 200, 0);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("../xml/list.xml"));

            //string filename = dt.Rows[i]["addtime"].ToString().Replace("-", "").Replace("/", "").Replace(":", "").Replace(" ", "");
            //XmlNode root = xmlDoc.SelectSingleNode("Blogs");//查找<bookstore>   
            //XmlElement xe1 = xmlDoc.CreateElement("Blog");//创建一个<book>节点    
            //xe1.SetAttribute("file", filename);

            //XmlElement xesub1 = xmlDoc.CreateElement("Title");
            //xesub1.InnerText = dt.Rows[i]["title"].ToString();//设置文本节点   
            //xe1.AppendChild(xesub1);//添加到<book>节点中   
            //XmlElement xesub2 = xmlDoc.CreateElement("Cover");
            //xesub2.InnerText = dt.Rows[i]["cover"].ToString();
            //xe1.AppendChild(xesub2);
            //XmlElement xesub3 = xmlDoc.CreateElement("Addtime");
            //xesub3.InnerText = dt.Rows[i]["addtime"].ToString(); ;
            //xe1.AppendChild(xesub3);

            //root.AppendChild(xe1);//添加到<bookstore>节点中   

            string filename = content.addtime.Replace("-", "").Replace("/", "").Replace(":", "").Replace(" ", "");
            XmlNode root = xmlDoc.SelectSingleNode("Blogs");//查找<bookstore>   
            XmlElement xe1 = xmlDoc.CreateElement("Blog");//创建一个<book>节点    
            xe1.SetAttribute("file", filename);

            XmlElement xesub1 = xmlDoc.CreateElement("Title");
            xesub1.InnerText = content.title;//设置文本节点   
            xe1.AppendChild(xesub1);//添加到<book>节点中   
            XmlElement xesub2 = xmlDoc.CreateElement("Cover");
            xesub2.InnerText = content.cover;
            xe1.AppendChild(xesub2);
            XmlElement xesub3 = xmlDoc.CreateElement("Addtime");
            xesub3.InnerText = content.addtime;
            xe1.AppendChild(xesub3);

            root.AppendChild(xe1);//添加到<bookstore>节点中   

            xmlDoc.Save(System.Web.HttpContext.Current.Server.MapPath("../xml/list.xml"));

        }

        #region 生成 详情xml
        /// <summary>
        /// 生成 详情xml
        /// </summary>
        /// <param name="content"></param>
        public void CreateXml(sModal.sContent content)
        {
            string filename = content.addtime.Replace("-", "").Replace("/", "").Replace(":", "").Replace(" ", "");
            XmlDocument xmldoc;
            //XmlNode xmlnode;
            XmlElement xmlelem;
            xmldoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>  
            XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldecl);
            //加入一个根元素  
            xmlelem = xmldoc.CreateElement("", "Blog", "");
            xmldoc.AppendChild(xmlelem);
            //加入另外一个元素  

            XmlNode root = xmldoc.SelectSingleNode("Blog");//查找<Employees>  
            XmlElement xe1 = xmldoc.CreateElement("Article");//创建一个<Node>节点  
            //xe1.SetAttribute("genre", "李赞红");//设置该节点genre属性  
            //xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性  
            XmlElement xesub1 = xmldoc.CreateElement("Title");
            xesub1.InnerText = content.title;//设置文本节点  
            xe1.AppendChild(xesub1);//添加到<Node>节点中  
            XmlElement xesub2 = xmldoc.CreateElement("Datetime");
            xesub2.InnerText = content.addtime;
            xe1.AppendChild(xesub2);
            XmlElement xesub3 = xmldoc.CreateElement("Content");
            xesub3.InnerText = Escape(content.content);
            xe1.AppendChild(xesub3);
            XmlElement xesub4 = xmldoc.CreateElement("Tags");
            xesub4.InnerText = content.tags;
            xe1.AppendChild(xesub4);
            XmlElement xesub5 = xmldoc.CreateElement("Filename");
            xesub5.InnerText = filename;
            xe1.AppendChild(xesub5);

            XmlElement xesub6 = xmldoc.CreateElement("Cover");
            xesub6.InnerText = content.cover;
            xe1.AppendChild(xesub6);

            XmlElement xesub7 = xmldoc.CreateElement("Tag");
            xesub7.InnerText = content.cover;
            xe1.AppendChild(xesub7);

            root.AppendChild(xe1);//添加到<Employees>节点中  

            //保存创建好的XML文档  
            //xmldoc.Save("data.xml");
            xmldoc.Save(System.Web.HttpContext.Current.Server.MapPath("../xml/" + filename + ".xml"));
        }
        #endregion

        /// <summary>
        /// Access to Xml List
        /// </summary>
        public bool AccessToXml()
        {
            try
            {
                DataTable dt = ContentPage(1, 1, 1, "");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("../xml/list.xml"));
                XmlNode root = xmlDoc.SelectSingleNode("Blogs");//查找<bookstore>  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filename = dt.Rows[i]["addtime"].ToString().Replace("-", "").Replace("/", "").Replace(":", "").Replace(" ", "");

                    XmlElement xe1 = xmlDoc.CreateElement("Blog");//创建一个<book>节点    
                    xe1.SetAttribute("file", filename);

                    XmlElement xesub1 = xmlDoc.CreateElement("Title");
                    xesub1.InnerText = dt.Rows[i]["title"].ToString();//设置文本节点   
                    xe1.AppendChild(xesub1);//添加到<book>节点中   
                    XmlElement xesub2 = xmlDoc.CreateElement("Cover");
                    xesub2.InnerText = dt.Rows[i]["cover"].ToString();
                    xe1.AppendChild(xesub2);
                    XmlElement xesub3 = xmlDoc.CreateElement("Addtime");
                    xesub3.InnerText = dt.Rows[i]["addtime"].ToString();
                    xe1.AppendChild(xesub3);

                    root.AppendChild(xe1);//添加到<bookstore>节点中   
                }
                xmlDoc.Save(System.Web.HttpContext.Current.Server.MapPath("../xml/list.xml"));
                return true;
            }
            catch
            {
                return false;
            }
        }



        public string Escape(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                sb.Append((Char.IsLetterOrDigit(c)
                || c == '-' || c == '_' || c == '\\'
                || c == '/' || c == '.') ? c.ToString() : Uri.HexEscape(c));
            }
            return sb.ToString();
        }

        public string UnEscape(string str)
        {
            StringBuilder sb = new StringBuilder();
            int len = str.Length;
            int i = 0;
            while (i != len)
            {
                if (Uri.IsHexEncoding(str, i))
                    sb.Append(Uri.HexUnescape(str, ref i));
                else
                    sb.Append(str[i++]);
            }
            return sb.ToString();
        } 

        //public bool CreateHtml()
        //{
        //    string sql = "Select *,(Select boardname from mz_board where id=mz_Content.boardid) as boardname from mz_Content where flag=0";
        //    DataTable dt = obj.Query(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        string filepublic = "../html/";
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string filepath = DateTime.Parse(dt.Rows[i]["addtime"].ToString()).Year.ToString();
        //            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(filepublic + filepath)))
        //            {
        //                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(filepublic + filepath));
        //            }

        //            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(filepublic + "Templete/HTMLPage.html"));

        //            StringBuilder htmltext = new StringBuilder(sr.ReadToEnd());

        //            htmltext.Replace("htmltitle", dt.Rows[i]["title"].ToString());
        //            htmltext.Replace("htmltime", dt.Rows[i]["addtime"].ToString());
        //            htmltext.Replace("htmlboard", dt.Rows[i]["boardname"].ToString());
        //            htmltext.Replace("htmltext", dt.Rows[i]["content"].ToString().Replace("../attached/", "/attached/"));
        //            htmltext.Replace("htmlid", dt.Rows[i]["id"].ToString());
        //            htmltext.Replace("boardid", dt.Rows[i]["boardid"].ToString());

        //            StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(filepublic + filepath + "/" + dt.Rows[i]["id"].ToString() + ".html"), false, System.Text.Encoding.GetEncoding("utf-8"));
        //            sw.WriteLine(htmltext);
        //            sw.Flush();
        //            sw.Close();
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public DataSet CXmlFileToDataSet(string xmlFilePath)
        {
            if (!string.IsNullOrEmpty(xmlFilePath))
            {
                string path = HttpContext.Current.Server.MapPath(xmlFilePath);
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    XmlDocument xmldoc = new XmlDocument();
                    //根据地址加载Xml文件  
                    xmldoc.Load(path);

                    DataSet ds = new DataSet();
                    //读取文件中的字符流  
                    StrStream = new StringReader(xmldoc.InnerXml);
                    //获取StrStream中的数据  
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据  
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源  
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }  

        public void ContentDelete(string id, string path)
        {
            string sql = "delete From mz_Content Where id=" + id;
            obj.Execute(sql);

            FileInfo fileM = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../html/" + path + "/" + id + ".html"));
            if (fileM.Exists) { fileM.Delete(); } //删除单个文件
        }

        public DataTable GetTags(string xmlFilePath)
        {
            //string sql = "Select * From mz_Tags";
            //return obj.Query(sql);

            string path = HttpContext.Current.Server.MapPath(xmlFilePath);
            StringReader StrStream = null;
            XmlTextReader Xmlrdr = null;
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                //根据地址加载Xml文件  
                xmldoc.Load(path);

                DataSet ds = new DataSet();
                //读取文件中的字符流  
                StrStream = new StringReader(xmldoc.InnerXml);
                //获取StrStream中的数据  
                Xmlrdr = new XmlTextReader(StrStream);
                //ds获取Xmlrdr中的数据  
                ds.ReadXml(Xmlrdr);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// tag删除
        /// </summary>
        /// <param name="tagid"></param>
        public void TagsDelete(int tagid)
        {
            string sql = "Delete From mz_Tags where id=" + tagid;
            obj.Execute(sql);
        }

        #region 获取分类table
        /// <summary>
        /// 获取分类table
        /// </summary>
        /// <returns></returns>
        public DataTable GetCategory()
        {
            string sql = "Select * From mz_board";
            return obj.Query(sql);
        }

        public DataTable GetCategory(int id)
        {
            string sql = "Select * From mz_board where id<>" + id;
            return obj.Query(sql);
        }
        #endregion

        public void ClearContent(int id)
        {
            string sql = "Delete From mz_Content where boardid=" + id;
            obj.Execute(sql);
        }
        public void DeleteCategory(int delid,int changid)
        {
            string sql = "Update mz_Content Set boardid=" + changid + " Where boardid=" + delid;
            string sql2 = "Delete From mz_board Where id=" + delid;
            obj.Execute(sql);
            obj.Execute(sql2);
        }

        public sModal.sCategory GetCategoryModal(int id)
        {
            string sql = "Select * From mz_board Where id=" + id;
            DataTable dr = obj.Query(sql);

            if (dr.Rows.Count > 0)
            {
                sModal.sCategory cate = new sModal.sCategory();
                cate.id = Convert.ToInt32(dr.Rows[0]["id"].ToString());
                cate.boardname = dr.Rows[0]["boardname"].ToString();
                return cate;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分类编辑
        /// </summary>
        /// <param name="cate"></param>
        public void CategoryUpdate(sModal.sCategory cate)
        {
            if (cate.id == 0)
            {
                string sql = "Insert Into mz_board (boardname) Values('" + cate.boardname + "')";
                obj.Execute(sql);
            }
            else
            {
                string sql = "Update mz_board Set boardname='" + cate.boardname + "' Where id=" + cate.id;
                obj.Execute(sql);
            }
        }
    }
}
