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

public class IntStringArray
{
	private string[] IntString;
	private int Length;

	public IntStringArray(int intValue)
	{   ///获取长度
		Length = intValue.ToString().Length;
		if(Length == 0)
		{
			Length = -1;
			return;
		}
		IntString = new string[Length];
		for(int i = 0; i < Length; i++)
		{   ///初始化数组
			IntString[i] = intValue.ToString()[i].ToString();
		}
	}

	public string this[int index]
	{
		get
		{
			if(index >= Length || index < 0)
			{
				return "";
			}
			///返回索引值
			return (IntString[index]);			
		}
		set
		{   ///设置索引值
			if(value.Length == 1)
			{
				IntString[index] = value;
			}
		}
	}
}


public partial class UsingIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		int intValue = 87654321;
		///定义类
		IntStringArray intString = new IntStringArray(intValue);
		for(int i = 0; i < intValue.ToString().Length; i++)
		{   ///使用索引器
			Response.Write((i + 1).ToString() + " : " + intString[i] + "<br>");
		}
		Response.End();
    }
}
