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
using System.Security.Policy;

public partial class UsingHash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TestHash();
    }

	private void TestHash()
	{
		Hashtable hashTable = new Hashtable();
		for(int i = 0; i < 10; i++)
		{
			hashTable.Add(i,i);
		}
		Response.Write(hashTable[5].ToString() + "<br>");
		foreach(DictionaryEntry entry in hashTable)
		{
			Response.Write("Key:" + entry.Key.ToString() + " Value:"
				+ entry.Value.ToString() + "<br>");
		}
		Response.End();	
	}
}
