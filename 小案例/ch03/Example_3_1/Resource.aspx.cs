using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void Deliver_Click(object sender,EventArgs e)
	{   ///使用Application对象存储数据
		Application.Lock();
		Application["Application"] = AppData.Text;
		Application.UnLock();
		///使用Session对象存储数据
		Session["Session"] = SesData.Text;
		///跳转到页面Direct.aspx
		Response.Redirect("~/Direct.aspx");
	}
}
