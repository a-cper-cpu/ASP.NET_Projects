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

public partial class Reader : System.Web.UI.Page
{
	int nMailID = -1;
	int nFolderID = -1;
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
		///获取参数nMailID的值
		if(Request.Params["MailID"] != null)
		{
			if(Int32.TryParse(Request.Params["MailID"].ToString(),out nMailID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示邮件内容
			if(nMailID > -1)
			{
				BindMailData(nMailID);
			}
		}
	}

	private void BindMailData(int nMailID)
	{
		IMail mail = new Mail();
		SqlDataReader dr = mail.GetSingleMail(nMailID);
		if(dr.Read())
		{
			Title.Text = dr["Title"].ToString();
			CC.Text = dr["CCAddress"].ToString();
			To.Text = dr["ToAddress"].ToString();
			Body.Text = dr["Body"].ToString();
			HtmlCB.Checked = bool.Parse(dr["HTMLFormat"].ToString().ToLower());

			SqlDataReader drAttach = mail.GetAttachmentsByMail(nMailID);
			AttachView.DataSource = drAttach;
			AttachView.DataBind();
			drAttach.Close();
		}
		dr.Close();
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		///返回到邮件列表页面
		Response.Redirect("~/ViewMail.aspx?FolderID=" + nFolderID.ToString());
	}
	protected void RecieverBtn_Click(object sender,EventArgs e)
	{	///回复邮件
		Response.Redirect("~/Sender.aspx?MailID=" + nMailID.ToString());
	}
}
