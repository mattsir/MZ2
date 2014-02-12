using System;
using System.Collections.Generic;
using BLL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.mzBoard
{
    public partial class ContentDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Request.QueryString["id"] == null) || (Request.QueryString["file"] == null))
                {

                }
                else
                {
                    ContentObj obj = new ContentObj();
                    obj.ContentDelete(Request.QueryString["id"].ToString(), Request.QueryString["file"].ToString());
                    string url = Request.UrlReferrer.ToString();
                    Response.Redirect(url);
                }
            }
        }
    }
}