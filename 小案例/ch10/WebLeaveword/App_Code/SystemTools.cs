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
