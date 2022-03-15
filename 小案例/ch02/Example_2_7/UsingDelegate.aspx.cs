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

public delegate string DelegatePrint(int intValue);

public class DelegateFeedBack
{	
	public string PrintString(int intValue)
	{
		if(intValue > 0)
		{
			return "这是一个正数。";
		}
		if(intValue < 0)
		{
			return "这是一个负数。";
		}
		return "这是一个0。";
	}

	public string PrintUpDown(int intValue)
	{
		if(intValue > 0)
		{
			return intValue.ToString() + " > 0";
		}
		if(intValue < 0)
		{
			return intValue.ToString() + " < 0";
		}
		return intValue.ToString() + " = 0";
	}
}

public partial class UsingDelegate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		DelegateFeedBack myDelegate = new DelegateFeedBack();
		DelegatePrint printString = new DelegatePrint(myDelegate.PrintString);
		DelegatePrint printletter = new DelegatePrint(myDelegate.PrintUpDown);

		Response.Write(printString(10) + "<br>");
		Response.Write(printletter(-100) + "<br>");
		Response.End();
    }
}
