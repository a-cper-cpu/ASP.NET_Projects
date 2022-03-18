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

public partial class EditView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void MyGridView_RowUpdating(object sender,GridViewUpdateEventArgs e)
	{   ///设置编辑的行
		MyGridView.EditIndex = e.RowIndex;
	}
	protected void MyGridView_RowUpdated(object sender,GridViewUpdatedEventArgs e)
	{   ///编辑之后,设置编辑的行
		MyGridView.EditIndex = -1;
	}
}
