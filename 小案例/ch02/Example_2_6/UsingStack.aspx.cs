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

public partial class UsingStack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			TestStack();
			Response.End();
		}
    }

	private void TestStack()
	{
		Stack stack = new Stack();
		///入栈
		for(int i = 0; i < 10; i++)
		{
			stack.Push(i);			
		}
		///出栈
		while(stack.Count > 0)
		{
			Response.Write(stack.Pop().ToString() + ",");
		}
	}
}
