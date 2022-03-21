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

public partial class AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void AddBtn_Click(object sender,EventArgs e)
	{
		if(Page.IsValid)
		{   ///定义对象
			User user = new User();

			try
			{   ///更新数据
				///user.AddUser(UserName.Text.Trim(),NewPassword.Text.Trim(),Email.Text.Trim());
				
                ///2006.12.7 zhengyd修改了该行程序代码：
                user.AddUser(UserName.Text.Trim(),user.Encrypt(NewPassword.Text.Trim()),Email.Text.Trim());
                Response.Write("<script>alert('" + "注册新用户成功，请妥善保管好你的信息！" + "');</script>");
			}
			catch(Exception ex)
			{   ///跳转到异常错误处理页面
				Response.Redirect("~/ErrorPage.aspx?ErrorMsg=" + ex.Message + "&ErrorUrl=" + Request.Url.ToString());
			}
		}
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/UserManage.aspx");
	}
}
