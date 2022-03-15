using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class StringAndBuilder : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			TestString();
		}
	}

	private void TestString()
	{
		///定义字符串
		string strold = "This is a string.";
		string strnew = strold;
		strnew = "This is a new string.";

		///输出字符串
		Response.Write("Old string: " + strold + "<br>");
		Response.Write("New string: " + strnew + "<br>");
		Response.Write("Old string(执行修改后): " + strold + "<br>");

		///定义StringBuilder
		StringBuilder sb = new StringBuilder(16,1000);

		///追加字符串
		sb.Append(strold);
		Response.Write("SB string: " + sb.ToString() + "<br>");

		///插入字符串
		sb.Insert(5,strnew);
		Response.Write("SB string: " + sb.ToString() + "<br>");

		///删除字符串
		sb.Remove(0,5);
		Response.Write("SB string: " + sb.ToString() + "<br>");

		///替换字符串
		sb.Replace("string","STRING");
		Response.Write("SB string: " + sb.ToString() + "<br>");

		///替换字符串
		int index = sb.ToString().IndexOf("STRING");
		sb.Replace("STRING","string",index,6);
		Response.Write("SB string: " + sb.ToString() + "<br>");

		Response.End();
	}	
}
