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

public partial class DesktopModules_ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!IsPostBack)
		{
			ViewState["BackURL"] = Request.UrlReferrer.ToString();
		}
	}
	
	protected void BackBtn_Click(object sender,System.EventArgs e)
	{
		Response.Redirect(ViewState["BackURL"].ToString());
	}
}
