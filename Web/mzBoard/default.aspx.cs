using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web.mzBoard
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContentObj obj = new ContentObj();
                if (obj.CheckAdmin())
                {

                }
                else
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
            }
        }
    }
}