using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.OleDb;
using System.Web;
using System.IO;

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
            string id;
            if (content.id == 0)
            {
                string sql = "Insert Into mz_Content (title,boardid,content,summary,tags,cover)" +
                    " Values('" + content.title + "'," + content.boardid + ",'" + content.content + "','" + content.summary + "','" + content.tags + "','" + content.cover + "')";
                obj.Execute(sql);
                string idsql = "Select top 1 id From mz_Content Order by id desc";
                DataTable dt = obj.Query(idsql);
                id = dt.Rows[0]["id"].ToString();
            }
            else
            {
                string sql = "Update mz_Content Set title='" + content.title + "',boardid=" + content.boardid + ",content='" + content.content + "',summary='" + content.summary + "',tags='" + content.tags + "',cover='" + content.cover + "' where id=" + content.id;
                obj.Execute(sql);
                id = content.id.ToString();
            }


            string filepublic = "../html/";
            string filepath = DateTime.Parse(content.addtime).Year.ToString();
            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(filepublic + filepath)))
            {
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(filepublic + filepath));
            }

            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(filepublic + "Templete/HTMLPage.html"));

            StringBuilder htmltext = new StringBuilder(sr.ReadToEnd());
            htmltext.Replace("htmltitle", content.title);
            htmltext.Replace("htmltime", content.addtime.ToString());
            htmltext.Replace("htmltext", content.content).Replace("../attached/", "/attached/");
            htmltext.Replace("htmlsummary", content.summary);
            //htmltext.Replace("boardid", content.boardid.ToString());

            StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(filepublic + filepath + "/" + id + ".html"), false, System.Text.Encoding.GetEncoding("utf-8"));
            sw.WriteLine(htmltext);
            sw.Flush();
            sw.Close();
        }

        public bool CreateHtml()
        {
            string sql = "Select *,(Select boardname from mz_board where id=mz_Content.boardid) as boardname from mz_Content where flag=0";
            DataTable dt = obj.Query(sql);
            if (dt.Rows.Count > 0)
            {
                string filepublic = "../html/";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filepath = DateTime.Parse(dt.Rows[i]["addtime"].ToString()).Year.ToString();
                    if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(filepublic + filepath)))
                    {
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(filepublic + filepath));
                    }

                    StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(filepublic + "Templete/HTMLPage.html"));

                    StringBuilder htmltext = new StringBuilder(sr.ReadToEnd());

                    htmltext.Replace("htmltitle", dt.Rows[i]["title"].ToString());
                    htmltext.Replace("htmltime", dt.Rows[i]["addtime"].ToString());
                    htmltext.Replace("htmlboard", dt.Rows[i]["boardname"].ToString());
                    htmltext.Replace("htmltext", dt.Rows[i]["content"].ToString().Replace("../attached/", "/attached/"));
                    htmltext.Replace("htmlid", dt.Rows[i]["id"].ToString());
                    htmltext.Replace("boardid", dt.Rows[i]["boardid"].ToString());

                    StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(filepublic + filepath + "/" + dt.Rows[i]["id"].ToString() + ".html"), false, System.Text.Encoding.GetEncoding("utf-8"));
                    sw.WriteLine(htmltext);
                    sw.Flush();
                    sw.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateDefault()
        {
            //string sql = "Select *,(Select boardname from mz_board where id=mz_Content.boardid) as boardname from mz_Content where flag=0";
            string sql = "Select * From mz_board";
            DataTable dt = obj.Query(sql);

            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath( "/html/Templete/default.html"));

            StringBuilder htmltext = new StringBuilder(sr.ReadToEnd());
            StringBuilder sp = new StringBuilder();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string boardid=dt.Rows[i]["id"].ToString();
                    string boardname = dt.Rows[i]["boardname"].ToString();
                    string sql2 = "Select top 1 * from mz_content where boardid=" + boardid+" Order by addtime desc";
                    DataTable dt2 = obj.Query(sql2);
                    int clo = i + 1;
                    sp.Append(" <div id=\"animate" + clo + "\" class=\"\">");
                    sp.Append("<img src=\"images/icon_channel" + clo + ".png\" border=\"0\" align=\"absmiddle\" /> <a href=\"html.html?id=" + boardid + "\">" + boardname + "</a></div>");
                    sp.Append("<div id=\"animateBox" + i + "\"></div>");

                    DateTime times = DateTime.Parse(dt2.Rows[0]["addtime"].ToString());
                    string dates = string.Format("{0:MM-dd}", times);

                    sp.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"margin-top:10px; margin-bottom:10px;\"><tr>");
                    sp.Append("<td class=\"fontgary\" style=\"padding-right:10px;text-align:left; vertical-align:top;\">");
                    sp.Append("<div class=\"div\">[" + dates + "] <a href=\"html/" + times.Year + "/" + dt2.Rows[0]["id"].ToString() + ".html\">" + dt2.Rows[0]["title"].ToString() + "</a></div>");
                    sp.Append("<span class=\"fontgary\">" + dt2.Rows[0]["summary"].ToString() + "</span></td>");
                    sp.Append("<td style=\"width:125px; vertical-align:top;text-align:left;\"><img src=\"attached/" + dt2.Rows[0]["cover"].ToString() + "\" style=\"border:#ffffff 3px solid;\" /></td>");
                    sp.Append("</tr></table>");

                    //htmltext.Replace("htmltitle", dt.Rows[i]["title"].ToString());
                    //htmltext.Replace("htmltime", dt.Rows[i]["addtime"].ToString());
                    //htmltext.Replace("htmlboard", dt.Rows[i]["boardname"].ToString());
                    //htmltext.Replace("htmltext", dt.Rows[i]["content"].ToString().Replace("../attached/", "/attached/"));
                    //htmltext.Replace("htmlid", dt.Rows[i]["id"].ToString());
                    //htmltext.Replace("boardid", dt.Rows[i]["boardid"].ToString());
                }

            htmltext.Replace("defaulthtml", sp.ToString());
            StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("/default.html"), false, System.Text.Encoding.GetEncoding("utf-8"));
            sw.WriteLine(htmltext);
            sw.Flush();
            sw.Close();
        }

        public void ContentDelete(string id, string path)
        {
            string sql = "delete From mz_Content Where id=" + id;
            obj.Execute(sql);

            FileInfo fileM = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../html/" + path + "/" + id + ".html"));
            if (fileM.Exists) { fileM.Delete(); } //删除单个文件
        }

        public DataTable GetTags()
        {
            string sql = "Select * From mz_Tags";
            return obj.Query(sql);
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
