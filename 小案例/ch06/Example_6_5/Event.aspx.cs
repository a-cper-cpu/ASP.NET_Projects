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

public partial class Event : System.Web.UI.Page
{
	private string EventID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
		if(Request.Params["EventID"] != null)
		{
			EventID = Request.Params["EventID"].ToString();
		}
		switch(EventID)
		{
			case "1": Response.Write("今天的事情"); break;
			case "2": Response.Write("明天的事情"); break;
			case "3": Response.Write("明天的事情 002"); break;
			case "4": Response.Write("下一周的事情"); break;
			default: break;
		}
		Response.End();
    }
}
