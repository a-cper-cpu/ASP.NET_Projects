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

public partial class SortView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void MyGridView_Sorted(object sender,EventArgs e)
	{
		///显示排序表达式
		LabelMsg.Text = "排序表达式为:" + @"""" + MyGridView.SortExpression + @"""";
	}
}
