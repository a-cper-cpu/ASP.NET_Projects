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

public partial class OverroadOperation : System.Web.UI.Page
{
	/// <summary>
	/// 定义结构Complex，表示一个复数
	/// </summary>
	public struct Complex
	{
		private int real;
		private int fraction;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="real"></param>
		/// <param name="fraction"></param>
		public Complex(int real,int fraction)
		{
			this.real = real;
			this.fraction = fraction;
		}

		/// <summary>
		/// 重载“+”运算符合
		/// </summary>
		/// <param name="leftValue"></param>
		/// <param name="rightValue"></param>
		/// <returns></returns>
		public static Complex operator +(Complex leftValue,Complex rightValue)
		{
			return (new Complex(leftValue.real + rightValue.real,
				leftValue.fraction + rightValue.fraction));
		}

		/// <summary>
		/// 打印复数
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public string Print()
		{
			return(real.ToString () + "." + fraction.ToString());
		}			
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			Complex left = new Complex(10,5);
			Complex right = new Complex(20,3);

			///使用重载的运算符合
			Complex result = left + right;
			Response.Write(result.Print());

			Response.End();
		}
    }
}
