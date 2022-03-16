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

public partial class ViewState : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		///
    }
	protected void Deliver_Click(object sender,EventArgs e)
	{   ///使用ViewState对象进行传递参数
		ViewState["ViewState"] = Data.Text;
		
		///获取ViewState对象中的数据
		if(ViewState["ViewState"] != null)
		{
			ReceData.Text = ViewState["ViewState"].ToString();
		}
	}
	protected void DeliverOther_Click(object sender,EventArgs e)
	{
		ViewState["ViewState"] = Data.Text;
		///跳转到页面Direct.aspx
		Response.Redirect("~/Direct.aspx");
	}
}