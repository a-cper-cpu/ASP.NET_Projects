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
		if(!Page.IsPostBack)
		{	///获取用户浏览器信息
			HttpBrowserCapabilities browser = Request.Browser;
			///设置客户端的属性值
			IP.Text = Request.UserHostAddress;
			OS.Text = browser.Platform;
			Browser.Text = browser.Browser;
			Vision.Text = browser.Version;
			Language.Text = Request.UserLanguages[0].ToString();
			IsCookie.Text = browser.Cookies == true ? "是" : "否";
			Date.Text = DateTime.Now.ToString();

			///判断用户是否已经访问
			if(Session["UserVisitor"] == null)
			{
				try
				{   ///定义对象
					IVisitor visitor = new Visitor();
					///执行数据库操作
					visitor.AddVisitor(Request.UserHostAddress,browser.Platform,browser.Browser,
						browser.Version,Language.Text,browser.Cookies);
					///添加已经访问的标志
					Session["UserVisitor"] = "UserVisitor";
				}
				catch(Exception ex)
				{   ///跳转到异常错误处理页面
					Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
						+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
				}
			}
		}	
    }
}
