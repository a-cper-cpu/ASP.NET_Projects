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

public partial class ViewMail:System.Web.UI.Page
{
	int nFolderID = -1;
	protected string AliasName = "AliasName";
	protected string Email = "Email";
	protected void Page_Load(object sender,EventArgs e)
	{
		///获取参数nFolderID的值
		if(Request.Params["FolderID"] != null)
		{
			if(Int32.TryParse(Request.Params["FolderID"].ToString(),out nFolderID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{
			if(nFolderID > -1)
			{
				BindMailData(nFolderID);
				BindFolderData();
			}
		}
		DeleteBtn.Attributes.Add("onclick","return confirm('你确定要删除所选择的邮件吗？');");
	}
	private void BindFolderData()
	{   ///获取数据
		IFolder folder = new Folder();
		SqlDataReader dr = folder.GetFolders();
		///绑定数据
		FolderList.DataSource = dr;
		FolderList.DataTextField = "Name";
		FolderList.DataValueField = "FolderID";
		FolderList.DataBind();
		dr.Close();
		
		MoveBtn.Enabled = FolderList.Items.Count > 0 ? true : false;
	}
	private void BindMailData(int nFolderID)
	{	///获取数据
		IMail mail = new Mail();
		SqlDataReader dr = mail.GetMailsByFloder(nFolderID);
		///绑定数据
		MailView.DataSource = dr;
		MailView.DataBind();
		dr.Close();

		DeleteBtn.Enabled = MailView.Rows.Count > 0 ? true : false;
	}

	protected void MoveBtn_Click(object sender,EventArgs e)
	{
		///定义对象
		IMail mail = new Mail();
		try
		{
			foreach(GridViewRow row in MailView.Rows)
			{   ///获取控件
				CheckBox checkMail = (CheckBox)row.FindControl("CheckMail");
				if(checkMail != null)
				{
					if(checkMail.Checked == true)
					{
						///执行数据库操作
						mail.MoveMail(Int32.Parse(MailView.DataKeys[row.RowIndex].Value.ToString()),
							Int32.Parse(FolderList.SelectedValue));
					}
				}
			}
			///重新绑定控件的数据
			BindMailData(nFolderID);
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}	
	protected void DeleteBtn_Click(object sender,EventArgs e)
	{
		///定义对象
		IMail mail = new Mail();
		try
		{
			foreach(GridViewRow row in MailView.Rows)
			{   ///获取控件
				CheckBox checkMail = (CheckBox)row.FindControl("CheckMail");
				if(checkMail != null)
				{
					if(checkMail.Checked == true)
					{
						///执行数据库操作
						mail.DeleteMail(Int32.Parse(MailView.DataKeys[row.RowIndex].Value.ToString()));
					}
				}
			}
			///重新绑定控件的数据
			BindMailData(nFolderID);
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}		
	}
}
