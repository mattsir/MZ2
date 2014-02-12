using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.mzBoard
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.name.Value;
            string pin = this.pin.Value;

            string nameo = ConfigurationSettings.AppSettings["name"].ToString();
            string pino = ConfigurationSettings.AppSettings["pin"].ToString();

            if (name.Equals(nameo) && pin.Equals(pino))
            {
                HttpCookie cookie = new HttpCookie("marsz");
                cookie.Value = name;
                cookie.Expires = DateTime.Now.AddHours(2);
                HttpContext.Current.Response.AppendCookie(cookie);

                Response.Redirect("ContentList.aspx?id=0");
                return;
            }
            else
            {
                Response.Redirect("login.aspx?err=1");
                return;
            }
        }
    }
}