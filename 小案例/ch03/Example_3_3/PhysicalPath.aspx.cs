using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class PhysicalPath : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			Response.Write("网站的物理地址：" + Server.MapPath("~") + "<br>");
			Response.Write("网站的虚拟地址：" + Request.ApplicationPath + "<br>");
			Response.Write("服务器的机器名：" + Server.MachineName + "<br>");
			Response.Write("请求的时间(秒)：" + Server.ScriptTimeout.ToString() + "<br>");
		}
    }
}
