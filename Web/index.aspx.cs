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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContentObj content = new ContentObj();
                DataTable dt = content.ContentPage(1, 100, 0);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
    }
}