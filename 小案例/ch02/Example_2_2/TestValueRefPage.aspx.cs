using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TestValueRefPage : System.Web.UI.Page 
{
	/// <summary>
	/// 引用类型，因为class是引用类型.
	/// </summary>
	public class RefType
	{
		public int Var;
	}

	/// <summary>
	/// 值类型，因为struct是值类型.
	/// </summary>
	public struct ValueType
	{
		public int Var;
	}	

	private void Page_Load(object sender,System.EventArgs e)
	{
		if(!Page.IsPostBack)
		{
			///测试值类型和引用类型
			TestValueRef();
			///测试装箱和拆箱
			TestBoxAndUnBox();
			///中止输出
			Response.End();
		}
	}

	private void TestValueRef()
	{
		///分别定义一个引用类型和值类型的实例
		///分配在堆上
		RefType reft = new RefType();
		///分配在栈上
		ValueType valuet = new ValueType();

		///赋值，Var的值均为100.
		reft.Var = 100;
		valuet.Var = 100;

		///显示Var的值
		Response.Write("RefType: Var=" + reft.Var.ToString() + "<br>");
		Response.Write("ValueType: Var=" + valuet.Var.ToString() + "<br>");

		///分别定义另外一个引用类型和值类型的实例，并分别指向reft和valuet
		RefType reftOther = reft;
		ValueType valuetOther = valuet;

		///对新的变量进行赋值
		reftOther.Var = 10;
		valuetOther.Var = 1000;

		///显示Var的值
		Response.Write("RefType(修改之前): Var=" + reft.Var.ToString() + "<br>");
		Response.Write("RefType(修改之后): Var=" + reftOther.Var.ToString() + "<br>");
		Response.Write("ValueType(修改之前): Var=" + valuet.Var.ToString() + "<br>");
		Response.Write("ValueType(修改之后): Var=" + valuetOther.Var.ToString() + "<br>");		
	}

	private void TestBoxAndUnBox()
	{
		int i = 10;
		object o = i;
		i = 100;
		Response.Write("i=" + i + ",o=" + (int)o);		
	}
}
