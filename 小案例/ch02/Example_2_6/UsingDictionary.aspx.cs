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
using System.Collections.Generic;

public partial class UsingDictionary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TestDictionary();
    }

	private void TestDictionary()
	{
		Dictionary<string,string> dic = new Dictionary<string,string>();
		///向字典中添加数据
		for(int i = 0; i < 10; i++)
		{
			dic.Add(i.ToString(),(100 * i).ToString());
		}
		///检测并输出数据
		for(int i = 0; i < dic.Count; i++)
		{
			Response.Write(dic[i.ToString()] + ", ");
		}
		Response.End();
	}
}
