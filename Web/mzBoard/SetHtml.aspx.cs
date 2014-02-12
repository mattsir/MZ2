using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web.mzBoard
{
    public partial class SetHtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ContentObj obj = new ContentObj();
            if (obj.CreateHtml())
            {
                txt.InnerHtml = "html文件生成成功";
            }
            else
            {
                txt.InnerHtml = "html文件生成不成功";
            }
            Button1.Visible = false;
        }
    }
}