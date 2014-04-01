using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL;

namespace Web.mzBoard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContentObj obj = new ContentObj();
                DataSet ds = obj.ContentPageds();
                ds.WriteXml(Server.MapPath("../xml/list1.xml")); 
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("../xml/list.xml"));
                //XmlNode root = xmlDoc.SelectSingleNode("Blogs");//查找<bookstore>  
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    string filename = dt.Rows[i]["addtime"].ToString().Replace("-", "").Replace("/", "").Replace(":", "").Replace(" ", "");

                //    XmlElement xe1 = xmlDoc.CreateElement("Blog");//创建一个<book>节点    
                //    xe1.SetAttribute("file", filename);

                //    XmlElement xesub1 = xmlDoc.CreateElement("Title");
                //    xesub1.InnerText = dt.Rows[i]["title"].ToString();//设置文本节点   
                //    xe1.AppendChild(xesub1);//添加到<book>节点中   
                //    XmlElement xesub2 = xmlDoc.CreateElement("Cover");
                //    xesub2.InnerText = dt.Rows[i]["cover"].ToString();
                //    xe1.AppendChild(xesub2);
                //    XmlElement xesub3 = xmlDoc.CreateElement("Addtime");
                //    xesub3.InnerText = dt.Rows[i]["addtime"].ToString();
                //    xe1.AppendChild(xesub3);

                //    root.AppendChild(xe1);//添加到<bookstore>节点中   
                //}
                //xmlDoc.Save(System.Web.HttpContext.Current.Server.MapPath("../xml/list1.xml"));
            }
        }

        public void Select(string xmlPath)
         {
             ContentObj obj = new ContentObj();
              XmlDocument xmlDoc = new XmlDocument();
             // xmlDoc.Load(xmlPath);
             // //取根结点
             // var root = xmlDoc.DocumentElement;//取到根结点
             ////取指定的单个结点
             // XmlNode oldChild = xmlDoc.SelectSingleNode("Article/Content");
             ////XmlNode od= oldChild.SelectSingleNode("Content");
             // string text = oldChild.InnerText;
             ////取指定的结点的集合
             ////XmlNodeList nodes = xmlDoc.SelectNodes("BookStore/NewBook");
              xmlDoc.Load(xmlPath);

              XmlNode xn = xmlDoc.SelectSingleNode("Blog");
              XmlNode xn1 = xn.SelectSingleNode("Article");
              XmlNodeList xnl = xn1.ChildNodes;
              string text = xnl.Item(0).InnerText;
              Response.Write(text);
              string texts =obj.UnEscape(xnl.Item(2).InnerText);
              Response.Write(texts);
              //foreach (XmlNode xn0 in xn1)
              //{
              //    string text = xn0.InnerText;
              //    Response.Write(text);
              //}
    // 得到根节点的所有子节点
    //XmlNodeList xnl = xn.ChildNodes;
    //XmlNode xnl = xn.SelectSingleNode("Article");
    //foreach (XmlNode xn1 in xnl)
    //{

        // 将节点转换为元素，便于得到节点的属性值
        //XmlElement xe = (XmlElement)xn1;
        // 得到Type和ISBN两个属性的属性值
        // bookModel.BookISBN = xe.GetAttribute("ISBN").ToString();
        // bookModel.BookType = xe.GetAttribute("Type").ToString();
        //// 得到Book节点的所有子节点
        //      XmlNode xnl0 = xn.SelectSingleNode("Content");
        //string text = xnl0.InnerText;
        ////bookModel.BookAuthor=xnl0.Item(1).InnerText;
        ////bookModel.BookPrice=Convert.ToDouble(xnl0.Item(2).InnerText);
        ////bookModeList.Add(bookModel);

        //Response.Write(text);

    //}


             //取到所有的xml结点
             
         }
    }
}