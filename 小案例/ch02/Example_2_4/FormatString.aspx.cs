using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class FormatString : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			TestFormatString();

			Response.End();
		}
    }

	private void TestFormatString()
	{
		string one = "one";
		string two = "two";
		string three = "three";
		
		///比较字符串
		int result = string.Compare(one,"ONE",false);
		Response.Write(result.ToString() + "<br>");	

		///连接字符串
		string andstring = string.Concat(one,two,three);
		Response.Write(andstring + "<br>");		

		///字符串格式化
		Response.Write(string.Format("This is a string,prev is {0},next is {1}.","PREV","NEXT") + "<br>");
		
		///字符串转换成整数
		string str100 = "100";
		string str200 = "200";
		int and = Int32.Parse(str100) + Int32.Parse(str200);
		Response.Write(and.ToString() + "<br>");


	}
}
