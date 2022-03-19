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

public partial class UsingTreeView : System.Web.UI.Page
{
	protected void Page_Load(object sender,EventArgs e)
	{
		if(!Page.IsPostBack)
		{   ///显示数据
			BindCategoryTreeView(CategoryView,true,"-1");
		}
	}	

	public void BindCategoryTreeView(TreeView treeView,bool isExpanded,string sSelectedData)
	{
		DataTable dataTable = GetCategorys().Tables[0];
		treeView.Nodes.Clear();     ///清空树的所有节点

		DataRow[] rowList = dataTable.Select("ParentID='-1'");
		if(rowList.Length <= 0) return;

		///创建根节点
		TreeNode rootNode = new TreeNode();
		///设置根节点属性
		rootNode.Text = rowList[0]["Desn"].ToString();
		rootNode.Value = rowList[0]["CategoryID"].ToString(); ///设置根节点的Key值
		rootNode.Expanded = isExpanded;
		rootNode.Selected = true;

		///添加根节点
		treeView.Nodes.Add(rootNode);

		///创建其他节点
		CreateChildNode(rootNode,dataTable,isExpanded,sSelectedData);
	}

	private void CreateChildNode(TreeNode parentNode,DataTable dataTable,bool isExpanded,
	   string sSelectedData)
	{
		///选择数据时，添加了排序表达式OrderBy
		DataRow[] rowList = dataTable.Select("ParentID='" + parentNode.Value + "'","OrderBy");
		foreach(DataRow row in rowList)
		{   ///创建新节点
			TreeNode node = new TreeNode();
			///设置节点的属性
			node.Text = row["Desn"].ToString();
			node.Value = row["CategoryID"].ToString();
			node.Expanded = isExpanded;
			if(node.Value == sSelectedData)
			{
				node.Selected = true;
			}

			parentNode.ChildNodes.Add(node);
			///递归调用，创建其他节点
			CreateChildNode(node,dataTable,isExpanded,sSelectedData);
		}
	}

	public DataSet GetCategorys()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		///定义SQL语句
		string cmdText = "SELECT * FROM Category";
		///创建Command
		SqlDataAdapter da = new SqlDataAdapter(cmdText,myConnection);

		///定义DataSet
		DataSet ds = new DataSet();
		try
		{
			///打开链接
			myConnection.Open();
			///读取数据
			da.Fill(ds);
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{
			myConnection.Close();
		}
		///返回DataSet
		return ds;
	}
}
