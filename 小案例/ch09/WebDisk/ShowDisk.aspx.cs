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

public partial class ShowDisk : System.Web.UI.Page
{
	private int nDirID = -1;
	private int nParentID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
		///获取参数DirID的值
		if(Request.Params["DirID"] != null)
		{
			if(Int32.TryParse(Request.Params["DirID"].ToString(),out nDirID) == false)
			{
				return;
			}
		}
		if(Request.Params["ParentID"] != null)
		{
			if(Int32.TryParse(Request.Params["ParentID"].ToString(),out nParentID) == false)
			{
				return;
			}
		}
		if(!Page.IsPostBack)
		{   ///显示目录列表的信息
			BindDirectoryData();
			if(nDirID > -1)   ///存在DirID > -1的情况
			{
				BindDirectoryData(nDirID);
				SystemTools.SetListBoxItem(DirList,nDirID.ToString());
				return;
			}
			if(nDirID <= -1 && nParentID > -1)   ///存在DirID > -1的情况
			{
				BindDirectoryData(nParentID);
				SystemTools.SetListBoxItem(DirList,nParentID.ToString());
				return;
			}		
			if(DirList.Items.Count > 0)
			{
				BindDirectoryData(Int32.Parse(DirList.SelectedValue));
			}
		}
	}
	private void BindDirectoryData()
	{   ///显示目录列表信息
		Disk disk = new Disk();
		disk.ShowDirectory(DirList,-1);

		if(DirList.Items.Count > 0)
		{
			DirList.SelectedIndex = 0;
		}

		disk.ShowDirectory(MoveDirList,-1);		
	}
	private void BindDirectoryData(int nParentID)
	{
		///显示目录列表信息
		IDisk disk = new Disk();
		SqlDataReader dr = disk.GetDirectoryFile(nParentID);
		///绑定控件的数据
		DiskView.DataSource = dr;
		DiskView.DataBind();
		dr.Close();

		ReturnBtn.Visible = nParentID > 0 ? true : false;
	}
	protected string FormatImageUrl(bool bFlag,string sType)
	{
		if(bFlag == true)
		{   ///文件类型
			return ("~/Images/folder.gif");
		}
		else
		{
			switch(sType)
			{   ///bmp文件
				case "image/bmp": return ("~/Images/bmp.bmp");
				///exe文件
				case "application/octet-stream": return ("~/Images/exe.bmp");					
				default: return("~/Images/other.gif");
			}
		}
		return ("");
	}
	protected string FormatHerf(int nDirID,int nParentID,bool bFlag)
	{
		if(bFlag == true)
		{
			return ("ShowDisk.aspx?DirID=" + nDirID.ToString() + "&ParentID=" + nParentID.ToString());
		}
		else
		{
			return ("ViewDisk.aspx?DirID=" + nDirID.ToString() + "&ParentID=" + nParentID.ToString());
		}
	}
	protected void DirList_SelectedIndexChanged(object sender,EventArgs e)
	{   ///绑定控件的数据
		BindDirectoryData(Int32.Parse(DirList.SelectedValue));
	}
	protected void MoveBtn_Click(object sender,EventArgs e)
	{
		try
		{   ///定义对象
			IDisk disk = new Disk();
			foreach(GridViewRow row in DiskView.Rows)
			{
				CheckBox dirCheck = (CheckBox)row.FindControl("DirCheck");
				if(dirCheck != null)
				{
					if(dirCheck.Checked == true)
					{
						///执行数据库操作
						disk.MoveDirectory(Int32.Parse(DiskView.DataKeys[row.RowIndex].Value.ToString()),
							Int32.Parse(MoveDirList.SelectedValue));
					}
				}				
			}
			///重新绑定控件的数据				
			BindDirectoryData(Int32.Parse(DirList.SelectedValue));
			Response.Write("<script>alert('" + "修改数据成功，请妥善保管好你的数据！" + "');</script>");
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		///返回到上级目录
		Response.Redirect("~/ShowDisk.aspx?DirID=" + nParentID.ToString());
	}
	protected void DiskView_RowCommand(object sender,GridViewCommandEventArgs e)
	{
		if(e.CommandName == "delete")
		{
			try
			{   ///删除数据
				IDisk disk = new Disk();
				disk.DeleteFile(Int32.Parse(e.CommandArgument.ToString()));

				///重新绑定控件的数据				
				BindDirectoryData(Int32.Parse(DirList.SelectedValue));
				Response.Write("<script>alert('" + "删除数据成功，请妥善保管好你的数据！" + "');</script>");
			}
			catch(Exception ex)
			{   ///跳转到异常错误处理页面
				Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
					+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
			}
		}
	}
	protected void DiskView_RowDeleting(object sender,GridViewDeleteEventArgs e)
	{
		///
	}
	protected void DiskView_RowDataBound(object sender,GridViewRowEventArgs e)
	{
		ImageButton deleteBtn = (ImageButton)e.Row.FindControl("DeleteBtn");
		if(deleteBtn != null)
		{
			deleteBtn.Attributes.Add("onclick","return confirm('你确定要删除所选择的数据项吗？');");
		}
	}
}
