using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using BLL;

namespace Web.mzBoard
{
    public partial class SetHtmlDone : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        public static string GetText()
        {
            ContentObj obj = new ContentObj();
            //for (int i = 0; i < 10; i++)
            //{
                Thread.Sleep(1000);
                try
                {
                    obj.CreateHtml();
                    return "All finished!";
                }
                catch (ThreadStateException stateException)
                {
                    return stateException.GetType().Name;
                }
            
        }  
    }
}