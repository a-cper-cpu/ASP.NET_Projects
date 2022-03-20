using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class NotNullValidate : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		ValidateMsg.Visible = false;
    }

	protected void ValidateBtn_Click(object sender,EventArgs e)
	{
		if(Page.IsValid)
		{
			ValidateMsg.Text = "用户输入验证合法！";
			ValidateMsg.Visible = true;
		}
		else
		{
			ValidateMsg.Text = "用户输入验证失败！";
			ValidateMsg.Visible = true;
		}
	}
}
