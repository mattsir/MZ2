using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.mzBoard
{
    public partial class CoverUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = this.FileUpload1.FileName;//获取上传文件的文件名,包括后缀
                string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名
                string DoFileName = "L_" + DateTime.Now.ToString("yyyyMMddhhmm") + ExtenName;
                if ((ExtenName.ToLower() != ".jpg") && (ExtenName.ToLower() != ".gif") && (ExtenName.ToLower() != ".png"))
                {
                    this.errMessage.Text = "图片格式：jpg、gif、png";
                    //Response.End();
                    return;
                }
                else if (FileUpload1.PostedFile.ContentLength > 1 * 1024 * 300)
                {
                    this.errMessage.Text = "图片大小:300K以内";
                    // Response.End();
                    return;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("../attached/" + DoFileName));

                    string strsyear = "<script>window.parent.SendParaToPage('ctl00_ContentPlaceHolder1_cover','" + DoFileName + "');</script>";
                    Page.RegisterStartupScript("step1", strsyear);
                }
            }
            else
            {
                this.errMessage.Text = "请选择图片";
            }
        }
    }
}