using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// SystemTools 的摘要说明
/// </summary>
public class SystemTools
{
	public SystemTools()
	{
		///
	}

	public SqlDataReader GetProfiles()
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);
		string cmdText = "SELECT * FROM Profile";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);

		///定义DataReader
		SqlDataReader dr = null;
		try
		{
			///打开链接
			myConnection.Open();
			///读取数据
			dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		///返回DataReader
		return dr;
	}

	public int SetRepeatVote(string sIsRepeatVote)
	{
		///创建链接
		SqlConnection myConnection = new SqlConnection(
			ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString);

		string cmdText = "UPDATE Profile SET IsRepeatVote = '" + sIsRepeatVote + "'";
		///创建Command
		SqlCommand myCommand = new SqlCommand(cmdText,myConnection);		

		///定义返回值
		int nResult = -1;

		try
		{
			///打开链接
			myConnection.Open();
			///执行SQL语句
			nResult = myCommand.ExecuteNonQuery();
		}
		catch(SqlException ex)
		{
			///抛出异常
			throw new Exception(ex.Message,ex);
		}
		finally
		{   ///关闭链接
			myConnection.Close();
		}
		///返回nResult
		return nResult;
	}

	public static void SetListBoxItem(ListBox listBox,string sItemValue)
	{
		int index = 0;
		foreach(ListItem item in listBox.Items)
		{
			///判断值是否相等，并且设置控件的SelectedIndex
			if(item.Value.ToLower() == sItemValue.ToLower())
			{
				listBox.SelectedIndex = index;
				break;
			}
			index++;
		}
	}

	public static void SetListBoxItem(DropDownList listBox,string sItemValue)
	{
		int index = 0;
		foreach(ListItem item in listBox.Items)
		{
			///判断值是否相等，并且设置控件的SelectedIndex
			if(item.Value.ToLower() == sItemValue.ToLower())
			{
				listBox.SelectedIndex = index;
				break;
			}
			index++;
		}
	}

	public static void SetListBoxItem(ListBox listBox,string sItemValue,bool IsBool)
	{
		int index = 0;
		if(IsBool == true)
		{
			sItemValue = sItemValue.ToLower() == "true" ? "1" : "0";
		}
		foreach(ListItem item in listBox.Items)
		{
			///判断值是否相等，并且设置控件的SelectedIndex
			if(item.Value.ToLower() == sItemValue.ToLower())
			{
				listBox.SelectedIndex = index;
				break;
			}
			index++;
		}
	}

	public static void SetListBoxItem(DropDownList listBox,string sItemValue,bool IsBool)
	{
		int index = 0;
		if(IsBool == true)
		{
			sItemValue = sItemValue.ToLower() == "true" ? "1" : "0";
		}
		foreach(ListItem item in listBox.Items)
		{
			///判断值是否相等，并且设置控件的SelectedIndex
			if(item.Value.ToLower() == sItemValue.ToLower())
			{
				listBox.SelectedIndex = index;
				break;
			}
			index++;
		}
	}
}
