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
using System.Text;

public partial class ViewDisk : System.Web.UI.Page
{
	int nFileID = -1;
	private int nParentID = -1;
	protected void Page_Load(object sender,EventArgs e)
	{
		///获取参数DirID的值
		if(Request.Params["DirID"] != null)
		{
			if(Int32.TryParse(Request.Params["DirID"].ToString(),out nFileID) == false)
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
		{   ///显示目录的名称
			if(nFileID > -1)
			{
				BindFileData(nFileID);
			}
		}
	}
	private void BindFileData(int nDirID)
	{
		IDisk disk = new Disk();
		SqlDataReader dr = disk.GetSingleFile(nFileID);
		if(dr.Read())
		{   ///获取文件的名称（包含后缀）
			Name.Text = dr["Name"].ToString();
			Type.Text = dr["Type"].ToString();
			Contain.Text = dr["Contain"].ToString() + "B";
			CreateDate.Text = dr["CreateDate"].ToString();
			
			///创建文件所在的目录
			Dir.Text = CreateDir(Int32.Parse(dr["DirID"].ToString()));
		}
		dr.Close();
		
	}
	public string CreateDir(int nDirID)
	{
		StringBuilder dirSB = new StringBuilder();
		IDisk disk = new Disk();
		DataTable dataTable = SystemTools.ConvertDataReaderToDataTable(disk.GetAllDirectoryFile());	

		DataRow[] rowList = dataTable.Select("DirID='" + nDirID.ToString() + "'");
		if(rowList.Length != 1) return("");		
		///创建其他目录
		InsertParentDir(dataTable,Int32.Parse(rowList[0]["ParentID"].ToString()),dirSB);
		return (dirSB.ToString());
	}

	private void InsertParentDir(DataTable dataTable,int nParentID,StringBuilder sDir)
	{
		if(nParentID <= -1)
		{
			return;
		}
		DataRow[] rowList = dataTable.Select("DirID='" + nParentID.ToString() + "'");
		if(rowList.Length != 1) return;
		sDir.Insert(0,rowList[0]["Name"].ToString() + "/");
		InsertParentDir(dataTable,Int32.Parse(rowList[0]["ParentID"].ToString()),sDir);
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{
		Response.Redirect("~/ShowDisk.aspx?ParentID=" + nParentID.ToString());
	}
}
