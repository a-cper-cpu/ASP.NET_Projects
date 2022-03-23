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
using System.Data.SqlClient;

public partial class ViewLeaveword : System.Web.UI.Page
{
	private int nLeavewordID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///获取参数TopicID的值
		if(Request.Params["LeavewordID"] != null)
		{
			if(Int32.TryParse(Request.Params["LeavewordID"].ToString(),out nLeavewordID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示数据
			if(nLeavewordID > -1)
			{
				BindLeavewordData(nLeavewordID);
			}
		}		
	}
	private void BindLeavewordData(int nLeavewordID)
	{   ///获取数据
		ILeaveword word = new Leaveword();
		SqlDataReader dr = word.GetSingleLeaveword(nLeavewordID);
		///读取数据
		if(dr.Read())
		{
			Title.Text = dr["Title"].ToString();
			LeavewordBody.Text = dr["Body"].ToString();
		}
		///关闭数据源
		dr.Close();
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/LeavewordManage.aspx");
	}
}
