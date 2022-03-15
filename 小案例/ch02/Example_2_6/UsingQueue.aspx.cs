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

public partial class UsingQueue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			TestQueue();
			Response.End();
		}
	}

	private void TestQueue()
	{
		Queue queue = new Queue();
		///入队
		for(int i = 0; i < 10; i++)
		{
			queue.Enqueue(i);
		}
		///出队
		while(queue.Count > 0)
		{
			Response.Write(queue.Dequeue().ToString() + ",");
		}
	}
}
