using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace Web.mzBoard
{
    public partial class Tag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        ContentObj obj = new ContentObj();
        public void bind()
        {
            DataTable dt = obj.GetTags();
            DataList1.DataSource = obj.GetTags();
            DataList1.DataBind();
        }
    }
}