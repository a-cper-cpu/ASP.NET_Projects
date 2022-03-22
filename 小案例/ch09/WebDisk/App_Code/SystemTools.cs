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

	/// <summary>
	/// 将DataReader转为DataTable
	/// </summary>
	/// <param name="DataReader">DataReader</param>
	public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
	{
		///定义DataTable
		DataTable datatable = new DataTable();

		try
		{	///动态添加表的数据列
			for(int i = 0; i < dataReader.FieldCount; i++)
			{
				DataColumn myDataColumn = new DataColumn();
				myDataColumn.DataType = dataReader.GetFieldType(i);
				myDataColumn.ColumnName = dataReader.GetName(i);
				datatable.Columns.Add(myDataColumn);
			}

			///添加表的数据
			while(dataReader.Read())
			{
				DataRow myDataRow = datatable.NewRow();
				for(int i = 0; i < dataReader.FieldCount; i++)
				{
					myDataRow[i] = dataReader[i].ToString();
				}
				datatable.Rows.Add(myDataRow);
				myDataRow = null;
			}
			///关闭数据读取器
			dataReader.Close();
			return datatable;
		}
		catch(Exception ex)
		{
			///抛出类型转换错误
			throw new Exception(ex.Message,ex);
		}
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
