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

public partial class StatByBrowser : System.Web.UI.Page
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
		///读取数据			
		while(dr.Read())
		{   ///统计每种浏览器的访问量
			AddStatByBrowser(dr,ref statList);
			total++;
		}
		dr.Close();
		if(total > 0)
		{
			for(int i = 0; i < statList.Count; i++)
			{   ///计算每种浏览器访问量的百分比
				((VisitStat)statList[i]).Percent = (int)((double)((VisitStat)statList[i]).Number * 100) / total;
			}
		}
		///绑定数据
		StatView.DataSource = statList;
		StatView.DataBind();
	}

	private void AddStatByBrowser(SqlDataReader dr,ref ArrayList statList)
	{   ///获取浏览器的名称
		string browserName = dr["Browser"].ToString();
		int i = 0;
		for(i = 0; i < statList.Count; i++)
		{   ///如果此浏览器已经统计，在数量加一
			if(((VisitStat)statList[i]).Name == browserName)
			{
				((VisitStat)statList[i]).Number++;
				break;
			}
		}
		///如果此浏览器没有被统计，则创建新的统计对象
		if(i == statList.Count)
		{
			VisitStat stat = new VisitStat();
			stat.Name = browserName;
			stat.Number = 1;
			stat.Percent = 0;
			statList.Add(stat);
		}
	}
}
