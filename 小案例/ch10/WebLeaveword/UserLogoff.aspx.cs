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

public partial class UserLogoff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		///清空Session中的内容，并停止Session
		Session["UserID"] = null;
		Session.Clear();
		Session.Abandon();

		///跳转到首页
		Response.Redirect("~/Default.aspx");
    }
}
