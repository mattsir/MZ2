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

                int totalOrders = (int)content.ContentTotal(0);
                number.Text = totalOrders.ToString();
                AspNetPager1.RecordCount = totalOrders;
                //bindData();
                bindCate();
            }
        }

        public void bindCate()
        {
            DataSet ds = content.CXmlFileToDataSet("../xml/list.xml");
            //Response.Write(ds.Tables[0].Rows.Count);
            //DataTable dt = content.GetCategory();
            //DataRow row = dt.NewRow();
            //row["id"] = "0";
            //row["boardname"] = "全部";
            //dt.Rows.Add(row);

            //datatable 编辑行
            //row.BeginEdit();
            //row["id"] = "0";
            //row["boardname"] = "全部";
            //row.EndEdit();

            int pageitem = 15;
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

            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.DataSource = ds.Tables[0].DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = pageitem;
            pds.CurrentPageIndex = page;
            Repeater1.DataSource = pds;
            Repeater1.DataBind();  
            
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


            //DataList1.DataSource = content.ContentPage(page, 30, id);
            //DataList1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            content.ClearContent(id);
            bindData();
        }
    }
}