using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TestBoxUnBox : System.Web.UI.Page 
{
	private void Page_Load(object sender,System.EventArgs e)
	{
		if(!Page.IsPostBack)
		{
			TestBoxAndUnBox();
		}
	}

	private void TestBoxAndUnBox()
	{
		int i = 10;
		object o = i;
		i = 100;
		Response.Write("i=" + i + ",o=" + (int)o);
		Response.End();
	}
}
