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

public partial class LeftTree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///初始化操作树
			InitOperationTree();
		}
    }

	private void InitOperationTree()
	{   ///获取数据
		IFolder folder = new Folder();
		SqlDataReader dr = folder.GetFolders();
		///找到“邮件文件夹”节点
		TreeNode mailFolderNode = OperationView.FindNode("-1/0");
		if(mailFolderNode == null)
		{
			return;
		}
		///添加邮件文件夹
		while(dr.Read())
		{   ///创建节点
			TreeNode node = new TreeNode();
			node.NavigateUrl = "~/ViewMail.aspx?FolderID=" + dr["FolderID"].ToString();
			node.Target = "Desktop";
			node.Text = dr["Name"].ToString();
			node.Value = dr["FolderID"].ToString();
			mailFolderNode.ChildNodes.Add(node);
		}
		dr.Close();
	}
}
