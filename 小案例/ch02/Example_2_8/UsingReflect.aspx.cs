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
using System.Reflection;

public class TestReflection
{
	public Assembly myAssembly;
	public TestReflection()
	{   ///获取程序集
		myAssembly = Assembly.GetExecutingAssembly();
	}	
}

public partial class UsingReflect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TestReflection reflection = new TestReflection();
		foreach(Module m in reflection.myAssembly.GetModules())
		{   ///输出模块信息
			Response.Write("Module: " + m.Name + "<br>");
			foreach(Type t in m.GetTypes())
			{   ///输出类型信息
				Response.Write("　　Type: " + t.Name + "<br>");
				foreach(MemberInfo mi in t.GetMembers())
				{   ///输出成员信息
					Response.Write("　　　　MemberInfo: " + mi.Name + "<br>");
				}
			}
		}
		Response.End();
    }
}
