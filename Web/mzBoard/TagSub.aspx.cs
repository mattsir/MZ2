using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Web.mzBoard
{
    public partial class TagSub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContentObj obj = new ContentObj();
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                obj.TagsDelete(id);
                Response.Redirect("Tag.aspx");
            }
        }
    }
}