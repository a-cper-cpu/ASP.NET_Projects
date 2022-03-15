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

public partial class ConvertOperation : System.Web.UI.Page
{
	public struct ConvertLetterToDigit
	{
		byte letter;

		/// <summary>
		/// 定义构造函数
		/// </summary>
		/// <param name="letter"></param>
		public ConvertLetterToDigit(byte letter)
		{
			if(letter > 9)
			{
				throw new System.ArgumentException();
			}

			this.letter = letter;
		}

		/// <summary>
		/// 定义转换运算符
		/// </summary>
		/// <param name="letter"></param>
		/// <returns></returns>
		public static explicit operator ConvertLetterToDigit(byte letter)
		{
			ConvertLetterToDigit d = new ConvertLetterToDigit(letter);
			return d;
		}
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			byte b = 1;
			try
			{
				///转换类型
				ConvertLetterToDigit d = (ConvertLetterToDigit)b;
				Response.Write(b.ToString());
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
			}
			Response.End();
		}

    }
}
