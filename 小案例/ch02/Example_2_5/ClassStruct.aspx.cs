using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ClassStruct : System.Web.UI.Page 
{
	/// <summary>
	/// 定义类
	/// </summary>
	public class AgeClass
	{
		/// <summary>
		/// 定义成员变量
		/// </summary>
		private int m_age;
		
		/// <summary>
		/// 定义方法GetAge()
		/// </summary>		
		public int GetAge()
		{
			return m_age;
		}

		/// <summary>
		/// 定义方法SetAge()
		/// </summary>	
		public void SetAge(int age)
		{
			m_age = age;
		}
	}

	public struct AgeStruct
	{
		/// <summary>
		/// 定义成员变量
		/// </summary>
		private int m_age;

		/// <summary>
		/// 定义方法GetAge()
		/// </summary>		
		public int GetAge()
		{
			return m_age;
		}

		/// <summary>
		/// 定义方法SetAge()
		/// </summary>	
		public void SetAge(int age)
		{
			m_age = age;
		}
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{
			///对象初始化
			AgeClass agec = new AgeClass();
			agec.SetAge(100);
			Response.Write("AgeClass's Age = " + agec.GetAge().ToString() + "<br>");

			///结构初始化
			AgeStruct ages = new AgeStruct();
			ages.SetAge(50);
			Response.Write("AgeStruct's Age = " + ages.GetAge().ToString() + "<br>");

			Response.End();
		}
    }
}
