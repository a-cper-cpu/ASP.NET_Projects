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

public partial class ViewPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void MyGridView_PageIndexChanged(object sender,EventArgs e)
	{   ///获取并显示当前页码
		LabelMsg.Text = "当前页码为:" + (MyGridView.PageIndex + 1).ToString();
	}
}
