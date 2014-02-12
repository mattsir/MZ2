using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        public void bind()
        {
            year.Text = DateTime.Now.Year.ToString();
            int pageitem = 18;
            ContentObj content = new ContentObj();
            int page;
            if (Request.QueryString["page"] == null)
            {
                page = 1;
            }
            else
            {
                if (int.TryParse(Request.QueryString["page"].ToString(), out page))
                {
                    page = page;
                }
                else
                {
                    page = 1;
                }
            }

            DataTable dt = content.ContentPage(page, pageitem, 0);

            Repeater1.DataSource = dt;
            Repeater1.DataBind();


            int totalOrders = (int)content.ContentTotal(0);
            int pagenumber = totalOrders / pageitem;
            int pagemod = totalOrders % pageitem;
            if (pagemod > 0)
            {
                pagenumber = pagenumber + 1;
            }
            if (page == 1)
            {
                pageright.Attributes["title"] = "下一页";
                pageright.Attributes["class"] = "pageright";
                pageright.Attributes["onclick"] = "javascript:location.assign('?page=2')";
            }
            else if (page == pagenumber)
            {
                pageleft.Attributes["title"] = "上一页";
                pageleft.Attributes["class"] = "pageleft";
                pageleft.Attributes["onclick"] = "javascript:location.assign('?page=" + (pagenumber - 1) + "')";
            }
            else
            {
                pageright.Attributes["title"] = "下一页";
                pageright.Attributes["class"] = "pageright";
                pageright.Attributes["onclick"] = "javascript:location.assign('?page=" + (page + 1) + "')";
                pageleft.Attributes["title"] = "上一页";
                pageleft.Attributes["class"] = "pageleft";
                pageleft.Attributes["onclick"] = "javascript:location.assign('?page=" + (page - 1) + "')";
            }
        }
    }
}