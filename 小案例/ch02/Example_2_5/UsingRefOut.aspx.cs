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

public partial class UsingRefOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		int indexRef = 1;
		TestRef(ref indexRef);
		int indexOut;
		TestOut(out indexOut);
		Response.Write("Ref: " + indexRef.ToString() + "<br>");
		Response.Write("Out: " + indexOut.ToString() + "<br>");
		Response.End();
    }

	private void TestRef(ref int index)
	{   ///不需要初始化
		for(int i = 0; i < 10; i++)
		{
			index += index;
		}
	}

	private void TestOut(out int index)
	{   ///初始化
		index = 1;
		for(int i = 0; i < 10; i++)
		{
			index += index;
		}
	}
}
