using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace Web.mzBoard
{
    public partial class ContentList : System.Web.UI.Page
    {
        public ContentObj content = new ContentObj();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    alert.Attributes["style"] = "display:block;";
                }
                else
                {
                    if (int.TryParse(Request.QueryString["id"].ToString(), out id))
                    {
                        EditLink.NavigateUrl = "CategoryUpdate.aspx?id="+id.ToString();
                        DeleLink.NavigateUrl = "CategoryDelete.aspx?id=" + id.ToString();
                        int totalOrders = (int)content.ContentTotal(id);
                        number.Text = totalOrders.ToString();
                        AspNetPager1.RecordCount = totalOrders;
                        bindData();
                        bindCate();
                    }
                    else
                    {
                        alert.Attributes["style"] = "display:block;";
                    }
                }
            }
        }

        public void bindCate()
        {
            DataTable dt = content.GetCategory();
            DataRow row = dt.NewRow();
            row["id"] = "0";
            row["boardname"] = "全部";
            dt.Rows.Add(row);
            //datatable 编辑行
            //row.BeginEdit();
            //row["id"] = "0";
            //row["boardname"] = "全部";
            //row.EndEdit();
            DataList2.DataSource = dt;
            DataList2.DataBind();
        }

        public void bindData()
        {
            int pageitem = 15;
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


            DataList1.DataSource = content.ContentPage(page, 30, id);
            DataList1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            content.ClearContent(id);
            bindData();
        }
    }
}