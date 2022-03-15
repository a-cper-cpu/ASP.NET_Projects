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

public partial class StringEncode : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///使用UTF8编码
			UTF8Encode();

			///使用UTF7编码
			UTF7Encode();

			///使用unicode编码
			UnicodeEncode();

			///使用ASCII编码
			ASCIIEncode();		
	
			///显示各种编码的信息
			ShowEncodeInformation(Encoding.Unicode);
			ShowEncodeInformation(Encoding.UTF32);
			ShowEncodeInformation(Encoding.UTF7);
			ShowEncodeInformation(Encoding.UTF8);
			ShowEncodeInformation(Encoding.ASCII);

			Response.End();
		}

    }

	/// <summary>
	/// 使用UTF8编码
	/// </summary>
	private void UTF8Encode()
	{
		Response.Write("使用UTF8编码：" + "<br>");
		string str = "123一二三";

		///使用UTF8编码
		Encoding utf8 = Encoding.UTF8;
		byte[] utf8Byte = utf8.GetBytes(str);
		Response.Write("编码后的字节数组:" + BitConverter.ToString(utf8Byte) + "<br>");

		///对byte数组进行解码
		string decodeStr = utf8.GetString(utf8Byte);
		Response.Write("解码后的字符串:" + decodeStr + "<br><br>");
	}

	/// <summary>
	/// 使用UTF7编码
	/// </summary>
	private void UTF7Encode()
	{
		Response.Write("使用UTF7编码：" + "<br>");
		string str = "123一二三";

		///使用UTF8编码
		Encoding utf7 = Encoding.UTF7;
		byte[] utf7Byte = utf7.GetBytes(str);
		Response.Write("编码后的字节数组:" + BitConverter.ToString(utf7Byte) + "<br>");

		///对byte数组进行解码
		string decodeStr = utf7.GetString(utf7Byte);
		Response.Write("解码后的字符串:" + decodeStr + "<br><br>");
	}

	/// <summary>
	/// 使用Unicode编码
	/// </summary>
	private void UnicodeEncode()
	{
		Response.Write("使用Unicode编码：" + "<br>");
		string str = "123一二三";

		///使用UTF8编码
		Encoding unicode = Encoding.Unicode;
		byte[] unicodeByte = unicode.GetBytes(str);
		Response.Write("编码后的字节数组:" + BitConverter.ToString(unicodeByte) + "<br>");

		///对byte数组进行解码
		string decodeStr = unicode.GetString(unicodeByte);
		Response.Write("解码后的字符串:" + decodeStr + "<br><br>");
	}

	/// <summary>
	/// 使用ASCII编码
	/// </summary>
	private void ASCIIEncode()
	{
		Response.Write("使用ASCII编码：" + "<br>");
		string str = "123一二三";

		///使用UTF8编码
		Encoding ascii = Encoding.ASCII;
		byte[] asciiByte = ascii.GetBytes(str);
		Response.Write("编码后的字节数组:" + BitConverter.ToString(asciiByte) + "<br>");

		///对byte数组进行解码
		string decodeStr = ascii.GetString(asciiByte);
		Response.Write("解码后的字符串:" + decodeStr + "<br><br>");
	}

	private void ShowEncodeInformation(Encoding e)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(e.EncodingName + "<br>");
		sb.Append("CodePage=" + e.CodePage.ToString());
		sb.Append(", HeaderName=" + e.HeaderName);
		sb.Append(", IsBrowserDisplay=" + e.IsBrowserDisplay.ToString());
		sb.Append(", IsBrowserSave=" + e.IsBrowserSave.ToString());
		sb.Append(", IsMailNewsDisplay=" + e.IsMailNewsDisplay.ToString());
		sb.Append(", IsReadOnly=" + e.IsReadOnly.ToString());
		sb.Append(", IsSingleByte=" + e.IsSingleByte.ToString());
		sb.Append(", WebName=" + e.WebName);
		sb.Append(", WindowsCodePage=" + e.WindowsCodePage.ToString());

		Response.Write(sb.ToString() + "<br><br>");
		
	}
}
