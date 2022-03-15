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
		{
			TestStatement();

			Response.End();
		}
    }

	private void TestStatement()
	{
		///使用for语句和if...else语句
		for(int i = 0; i < 101; i++)
		{
			Response.Write(i.ToString());
			if(i == 0)
			{
				Response.Write(", ");
			}
			else
			{
				if(i % 10 == 0)
				{
					Response.Write("<br>");
				}
				else
				{
					Response.Write(", ");
				}
			}
		}

		///使用while循环语言
		int j = 0;
		while(j < 10)
		{
			Response.Write("This is an int number and it equal " + j.ToString() + "<br>");
			j++;
		}

		///使用do...while循环语句
		int k = 0;
		do
		{
			Response.Write("This is an another int number and it equal " + k.ToString() + "<br>");
			k++;
		}
		while(k < 10);
	}
}
