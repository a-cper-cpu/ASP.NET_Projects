using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
	protected void Page_Load(Object o,EventArgs e)
	{
		cal1.DataSource = GetEventData();
	}

	DataTable GetEventData()
	{
		DataTable dt = new DataTable();
		dt.Columns.Add("EventID",typeof(int));
		dt.Columns.Add("Title",typeof(String));
		dt.Columns.Add("Day",typeof(DateTime));
		dt.Columns.Add("Color",typeof(System.Drawing.Color));

		DataRow r = dt.NewRow();
		r["EventID"] = 1;
		r["Title"] = "今天的事情";
		r["Day"] = System.DateTime.Today;
		r["Color"] = System.Drawing.Color.Black;
		dt.Rows.Add(r);

		r = dt.NewRow();
		r["EventID"] = 2;
		r["Title"] = "明天的事情";
		r["Day"] = System.DateTime.Today.AddDays(1);
		r["Color"] = System.Drawing.Color.Red;
		dt.Rows.Add(r);

		r = dt.NewRow();
		r["EventID"] = 3;
		r["Title"] = "明天的事情 002";
		r["Day"] = System.DateTime.Today.AddDays(1);
		r["Color"] = System.Drawing.Color.Blue;
		dt.Rows.Add(r);

		r = dt.NewRow();
		r["EventID"] = 4;
		r["Title"] = "下一周的事情";
		r["Day"] = System.DateTime.Today.AddDays(7);
		r["Color"] = System.Drawing.Color.Green;
		dt.Rows.Add(r);
		return dt;
	}
}
