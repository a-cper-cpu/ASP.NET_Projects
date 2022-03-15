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

public partial class UsingArrayList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TestArrayList();
    }
	private void TestArrayList()
	{
		ArrayList aList = new ArrayList();
		///添加数据
		for(int i = 0; i < 10; i++)
		{
			aList.Add(i);
		}
		for(int i = 0; i < 10; i++)
		{   ///输出数据
			Response.Write(aList[i].ToString() + ", ");
		}
		Response.End();
	}
}
