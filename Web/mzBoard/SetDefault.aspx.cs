using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web.mzBoard
{
    public partial class SetDefault : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContentObj obj = new ContentObj();
                obj.CreateDefault();
                inner.InnerHtml="首页生成成功";
            }
        }

    }
}