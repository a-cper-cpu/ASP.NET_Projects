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
		{   ///读取Web.config文件
			Response.Write("数据库链接字符串:"
				+ ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		}		
    }
}
