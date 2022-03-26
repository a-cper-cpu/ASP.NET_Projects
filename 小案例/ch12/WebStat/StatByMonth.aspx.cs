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
using System.Data.SqlClient;

public partial class StatByMonth : System.Web.UI.Page
{
	protected int total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
		if(!Page.IsPostBack)
		{   ///绑定控件的数据
			string dtString = YearList.SelectedItem.Text + "-1-1";
			BindVisitData(DateTime.Parse(dtString));
		}
	}
	private void BindVisitData(DateTime dDate)
	{   ///按照年份从数据库获取访问日志
		IVisitor visit = new Visitor();
		SqlDataReader dr = visit.GetVisitorsByYear(dDate);
		///创建数组
		ArrayList statList = new ArrayList();
		DateTime dt = dDate;
		///添加12个月
		for(int i = 0; i < 12; i++)
		{
			VisitStat stat = new VisitStat();
			stat.Name = (i + 1).ToString() + "月";
			stat.Number = 0;
			stat.Percent = 0;
			statList.Add(stat);
		}
		///读取数据
		//int total = 0;
		while(dr.Read())
		{   ///统计每月的访问量
			dt = DateTime.Parse(dr["VisitDate"].ToString());
			((VisitStat)statList[dt.Month - 1]).Number++;
			total++;
		}
		dr.Close();
		if(total > 0)
		{
			dt = dDate;
			for(int i = 0; i < 12; i++)
			{   ///计算每月访问量的百分比
				((VisitStat)statList[i]).Percent = (int)((double)((VisitStat)statList[i]).Number * 100) / total;
			}
		}
		///绑定数据
		StatView.DataSource = statList;
		StatView.DataBind();
	}

	protected void YearList_SelectedIndexChanged(object sender,EventArgs e)
	{   ///重新绑定控件的数据
		string dtString = YearList.SelectedItem.Text + "-1-1";
		BindVisitData(DateTime.Parse(dtString));
	}
}
