using System;
using System.Collections.Generic;
using BLL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.mzBoard
{
    public partial class CategoryUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ids;
                if (!int.TryParse(Request.QueryString["id"].ToString(), out ids))
                {
                    alert.Attributes["style"] = "display:block;";
                }
                else
                {
                    if (Request.QueryString["id"].ToString() == "0")
                    {
                    }
                    else
                    {
                        ContentObj obj = new ContentObj();
                        sModal.sCategory cate = obj.GetCategoryModal(ids);
                        if (cate == null)
                        {
                            alert.Attributes["style"] = "display:block;";
                        }
                        else
                        {
                            id.Text = cate.id.ToString();
                            name.Text = cate.boardname;
                        }
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            sModal.sCategory cate = new sModal.sCategory();
            cate.id = Convert.ToInt32(id.Text);
            cate.boardname = name.Text;

            ContentObj obj = new ContentObj();
            obj.CategoryUpdate(cate);
            string strsyear = "<script>window.parent.reloadpage();</script>";
            Page.RegisterStartupScript("step1", strsyear);
        }
    }
}