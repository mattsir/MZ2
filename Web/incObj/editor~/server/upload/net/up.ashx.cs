using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.JsObj.editor1.8.1.server.upload.net
{
    /// <summary>
    /// up 的摘要说明
    /// </summary>
    public class up : IHttpHandler {

        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}