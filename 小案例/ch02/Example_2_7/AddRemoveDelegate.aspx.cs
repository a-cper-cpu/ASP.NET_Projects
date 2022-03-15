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

public class TestEvent:System.Web.UI.UserControl
{
	private event EventHandler _print;
	public event EventHandler StringPrint
	{
		add
		{   ///添加事件
			_print += value;

		}
		remove
		{   ///移除事件
			_print -= value;
		}
	}

	public void TestPrint(object sender,EventArgs e)
	{   ///测试事件
		_print(sender,e);
	}
}
public partial class AddAddRemoveDelegate:System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TestEvent eventS = new TestEvent();
		///添加事件
		eventS.StringPrint += new EventHandler(eventS_StringPrint);
		eventS.TestPrint("This is a string.",new EventArgs());

		///异常事件
		eventS.StringPrint -= eventS_StringPrint;
		Response.End();
    }

	void eventS_StringPrint(object sender,EventArgs e)
	{
		Response.Write(sender.ToString() + "<br>");
	}
}
