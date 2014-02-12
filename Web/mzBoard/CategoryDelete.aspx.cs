using System;
using System.Collections.Generic;
using BLL;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.mzBoard
{
    public partial class CategoryDelete : System.Web.UI.Page
    {
        ContentObj obj = new ContentObj();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int cateid=Convert.ToInt32(Request.QueryString["id"].ToString());
                //if (!int.TryParse(Request.QueryString["id"].ToString(),out cateid))
                //{
                //    alert.Attributes["style"]="display:block";
                //}
                //else
                //{
                    sModal.sCategory cate = obj.GetCategoryModal(cateid);
                    if (cate == null)
                    {
                        alert.Attributes["style"] = "display:block";
                    }
                    else
                    {
                        catename.Text = cate.boardname;
                        id.Text = cate.id.ToString();
                        changecate.DataSource = obj.GetCategory(cateid);
                        changecate.DataTextField = "boardname";
                        changecate.DataValueField = "id";
                        changecate.DataBind();
                    }
                //}
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int delid = Convert.ToInt32(id.Text);
            int changeid = Convert.ToInt32(changecate.SelectedValue);
            obj.DeleteCategory(delid, changeid);
            string strsyear = "<script>window.parent.reloadpage();</script>";
            Page.RegisterStartupScript("step1", strsyear);
        }
    }
}