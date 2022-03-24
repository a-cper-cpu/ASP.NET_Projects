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
using System.Data.SqlClient;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///获取系统配置信息
			BindWebMailProfile();
		}
    }
	private void BindWebMailProfile()
	{
		if(Session["Profile"] == null)
		{
			///获取系统配置信息
			IMail mail = new Mail();
			SqlDataReader dr = mail.GetWebMailProfile();
			if(dr.Read())
			{
				WebMailProfile profile = new WebMailProfile();
				profile.UserName = dr["UserName"].ToString();
				profile.AliasName = dr["AliasName"].ToString();
				profile.Email = dr["Email"].ToString();
				profile.MailServerIP = dr["MailServerIP"].ToString();
				profile.MailServerPort = Int32.Parse(dr["MailServerPort"].ToString());
				///保存邮件配置属性到应用程序上下文中
				HttpContext.Current.Application.Add("WebMailProfile",profile);
			}
			dr.Close();
			Session["Profile"] = "Profile";
		}
	}
}
