using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web.mzBoard
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"].ToString(), out id))
                    {
                        bindpage(id);
                    }
                }
                else
                {
                    addtime.Text = DateTime.Now.ToString();
                }
            }
        }
        ContentObj obj = new ContentObj();
        public void bind()
        {
            board.DataSource = obj.GetCategory();
            board.DataTextField = "boardname";
            board.DataValueField = "id";
            board.DataBind();

            taglist.DataSource = obj.GetTags();
            taglist.DataBind();
        }

        public string GetContent()
        {
            if (Request.QueryString["id"] == null)
            {
                return "";
            }
            else
            {
                sModal.sContent content = obj.GetContent(Int32.Parse(Request.QueryString["id"].ToString()));
                if (content != null)
                {
                    return content.content;
                }
                else
                {
                    return "";
                }
            }
        }
        public void bindpage(int ids)
        {
            sModal.sContent content = obj.GetContent(ids);
            //if (content == null)
            //{
            //}
            title.Value = content.title;
            board.SelectedValue = content.boardid.ToString();
            summary.Value = content.summary;
            cover.Value = content.cover;
            tags.Value = content.tags;
            id.Text = content.id.ToString();
            addtime.Text = content.addtime;
            //myEditor.InnerHtml = content.content;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            sModal.sContent content = new sModal.sContent();
            content.id = Convert.ToInt32(this.id.Text);
            content.title = this.title.Value;
            content.boardid = Convert.ToInt32(board.SelectedValue);
            content.content = Request.Form["editorValue"].ToString();
            content.summary = summary.Value;
            content.cover = cover.Value;
            content.tags = tags.Value;
            content.addtime = addtime.Text;
            ContentObj obj = new ContentObj();
            obj.ContentUpdate(content);
            Response.Redirect("ContentList.aspx?id=" + board.SelectedValue);
        }
    }
}