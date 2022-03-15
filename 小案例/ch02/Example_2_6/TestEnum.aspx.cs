using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TestEnum : System.Web.UI.Page 
{
	/// <summary>
	/// 定义星期的枚举
	/// </summary>
	public enum Week
	{
		Sunday,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday
	}

	protected void Page_Load(object sender,System.EventArgs e)
	{
		if(!Page.IsPostBack)
		{
			TestEnumType();

			///验证"WeekDay"是否在枚举Week中定义
			Week weekDay = (Week)100;
			ValiateEnum(weekDay);

			Response.End();
		}
	}

	private void TestEnumType()
	{
		///获取枚举的值
		Week[] weekList = (Week[])Enum.GetValues(typeof(Week));
		foreach(Week w in weekList)
		{
			Response.Write(w.ToString("D") + "\t" + w.ToString("G") + "<br>");
		}

		///获取枚举的名称
		string[] nameList = Enum.GetNames(typeof(Week));
		foreach(string s in nameList)
		{
			Response.Write(s + "<br>");
		}

		///获取枚举的名称
		Response.Write(Enum.GetName(typeof(Week),3) + "<br>");
		Response.Write(Enum.GetName(typeof(Week),Week.Wednesday) + "<br>");

		///获取枚举的基类
		Response.Write("Base Class is: " + Enum.GetUnderlyingType(typeof(Week)) + "<br>");
	}

	private void ValiateEnum(Week w)
	{
		///测试枚举值是否被定义
		if(Enum.IsDefined(typeof(Week),w) == false)
		{
			Response.Write(w.ToString() + "is not exist.<br>");
		}
		else
		{
			Response.Write(w.ToString() + "\t is exist.<br>");
		}
	}
}
