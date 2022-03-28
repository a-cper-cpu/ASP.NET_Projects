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

public partial class AddItem : System.Web.UI.Page
{
	private int nSubjectID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{   ///获取参数TopicID的值
		if(Request.Params["SubjectID"] != null)
		{
			if(Int32.TryParse(Request.Params["SubjectID"].ToString(),out nSubjectID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示数据
			if(nSubjectID > -1)
			{
				BindSubjectData(nSubjectID);
			}
		}
		AddBtn.Enabled = nSubjectID > -1 ? true : false;
	}	
	private void BindSubjectData(int nSubjectID)
	{   ///获取数据
		ISubject subject = new Subject();
		SqlDataReader dr = subject.GetSingleSubject(nSubjectID);
		///读取数据
		if(dr.Read())
		{
			SubjectName.Text = dr["Name"].ToString();
		}
		///关闭数据源
		dr.Close();
	}

	protected void AddBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IItem item = new Item();
			///执行数据库操作
			item.AddItem(Name.Text.Trim(),nSubjectID);
			Response.Write("<script>alert('" + "添加数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{   ///跳转到管理页面
		Response.Redirect("~/ItemManage.aspx");
	}
}
