using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CustomerValidate : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		ValidateMsg.Visible = false;
    }

	protected void ValidateBtn_Click(object sender,EventArgs e)
	{
		if(InputBox.Text == "" || InputBoxLetter.Text == "")
		{
			ValidateMsg.Text = "用户输入验证失败，输入值为空！";
			ValidateMsg.Visible = true;
			return;
		}

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
	
	protected void cvInput_ServerValidate(object source,ServerValidateEventArgs args)
	{
		args.IsValid = false;

		try
		{
			int number = Int32.Parse(args.Value);
			if(number % 2 == 0)
			{
				args.IsValid = true;
			}
		}
		catch(Exception ex)
		{
			Response.Write("<script>alert(\"" + ex.Message + "\")</script>");
		}
	}

	protected void cvNumber_ServerValidate(object source,ServerValidateEventArgs args)
	{
		args.IsValid = false;

		try
		{
			int number = 0;
			if(Int32.TryParse(args.Value,out number) == true)
			{
				if(number % 3 == 0)
				{
					args.IsValid = true;
				}
			}
		}
		catch(Exception ex)
		{
			Response.Write("<script>alert(\"" + ex.Message + "\")</script>");
		}
	}
}
