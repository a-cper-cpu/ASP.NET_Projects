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

public partial class StatByWeek : System.Web.UI.Page
{
    protected int total = 0;
	protected void Page_Load(object sender,EventArgs e)
	{
		if(!Page.IsPostBack)
		{   ///绑定控件的数据
			BindVisitData();
		}
	}
	private void BindVisitData()
	{   ///从数据库获取访问日志
		IVisitor visit = new Visitor();
		SqlDataReader dr = visit.GetVisitors();
		///创建数组		
		ArrayList statList = new ArrayList();
		for(int i = 0; i < 7; i++)
		{
			VisitStat stat = new VisitStat();
			stat.Name = ((DayOfWeek)i).ToString();
			stat.Number = 0;
			stat.Percent = 0;
			statList.Add(stat);
		}
		DateTime dt;
		///读取数据			
		while(dr.Read())
		{   ///统计每星期的访问量
			dt = DateTime.Parse(dr["VisitDate"].ToString());
			((VisitStat)statList[(int)dt.DayOfWeek]).Number++;
			total++;
		}
		dr.Close();
		if(total > 0)
		{
			for(int i = 0; i < statList.Count; i++)
			{   ///计算每星期访问量的百分比
				((VisitStat)statList[i]).Percent = (int)((double)((VisitStat)statList[i]).Number * 100) / total;
			}
		}
		///绑定数据
		StatView.DataSource = statList;
		StatView.DataBind();
	}
}
