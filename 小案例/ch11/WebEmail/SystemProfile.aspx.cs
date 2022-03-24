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

public partial class SystemProfile:System.Web.UI.Page
{
	protected void Page_Load(object sender,EventArgs e)
	{	
		if(!Page.IsPostBack)
		{   ///显示系统配置信息
			BindWebMailProfile();
		}
	}

	private void BindWebMailProfile()
	{   ///获取系统配置信息
		IMail mail = new Mail();
		SqlDataReader dr = mail.GetWebMailProfile();
		if(dr.Read())
		{
			UserName.Text = dr["UserName"].ToString();
			AliasName.Text = dr["AliasName"].ToString();
			Email.Text = dr["Email"].ToString();
			IP.Text = dr["MailServerIP"].ToString();
			Port.Text = dr["MailServerPort"].ToString();
		}
		dr.Close();
	}
	protected void SetBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IMail mail = new Mail();
			///执行数据库操作
			mail.WebMailProfile(UserName.Text.Trim(),AliasName.Text.Trim(),Email.Text.Trim(),
				IP.Text.Trim(),Int32.Parse(Port.Text.Trim()));
			Response.Write("<script>alert('" + "配置系统数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}		
	}
}
