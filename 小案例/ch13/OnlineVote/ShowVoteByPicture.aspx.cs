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

public partial class ShowVoteByPicture : System.Web.UI.Page
{
	private static string sHeadText = "";
	protected void Page_Load(object sender,EventArgs e)
	{
		if(!Page.IsPostBack)
		{
			///显示当前投票主题的信息
			BindSubjectData(GetCurrentTopic());
		}
		VoteView.HeaderRow.Cells[0].Text = sHeadText;
	}
	private int GetCurrentTopic()
	{
		ITopic topic = new Topic();
		SqlDataReader dr = topic.GetCurrentTopic();

		int nCurrentTopicID = -1;
		if(dr.Read())
		{
			nCurrentTopicID = Int32.Parse(dr["TopicID"].ToString());
			sHeadText = dr["Name"].ToString();
		}
		dr.Close();
		return (nCurrentTopicID);
	}
	private void BindSubjectData(int nTopicID)
	{   ///获取数据
		ISubject subject = new Subject();
		SqlDataReader dr = subject.GetSubjectByTopic(nTopicID);
		///绑定数据
		VoteView.DataSource = dr;
		VoteView.DataBind();
		///关闭数据源
		dr.Close();
	}
	//private void BindItemData(GridView ItemView,int nSubjectID)
	//{   ///获取数据
	//    IItem item = new Item();
	//    SqlDataReader dr = item.GetItemBySubject(nSubjectID);
	//    ///绑定数据
	//    ItemView.DataSource = dr;
	//    ItemView.DataBind();		
	//    ///关闭数据源
	//    dr.Close();
	//}
	private void BindItemData(GridView ItemView,int nSubjectID)
	{   ///获取数据
		IItem item = new Item();
		SqlDataReader dr = item.GetItemBySubject(nSubjectID);
		SqlDataReader drs = item.GetItemVoteCountBySubject(nSubjectID);

		string sSumVoteCount = "";
		if(drs.Read())
		{
			sSumVoteCount = drs["SumVoteCount"].ToString();
		}
		
		ArrayList ItemInfoList = new ArrayList();
		while(dr.Read())
		{
			ItemInformation itemInfo = new ItemInformation();
			itemInfo.VoteCount = dr["VoteCount"].ToString();
			itemInfo.SumVoteCount = sSumVoteCount;
			itemInfo.Name = dr["Name"].ToString();
			ItemInfoList.Add(itemInfo);
		}
		///关闭数据源
		dr.Close();
		drs.Close();

		///绑定数据
		ItemView.DataSource = ItemInfoList;
		ItemView.DataBind();		
	}
	protected void VoteView_RowDataBound(object sender,GridViewRowEventArgs e)
	{
		GridView voteInofView = (GridView)e.Row.FindControl("VoteInfoView");
		if(voteInofView != null)
		{
			BindItemData(voteInofView,
				Int32.Parse(VoteView.DataKeys[e.Row.RowIndex].Value.ToString()));
		}
	}

	public int FormatVoteCount(String voteCount,string voteTotal)
	{
		if(voteCount.Length <= 0 || voteTotal.Length <= 0)
		{
			return (0);
		}
		int nVoteTotal = Int32.Parse(voteTotal);
		if(nVoteTotal > 0)
		{
			return ((Int32.Parse(voteCount) * 100 / nVoteTotal));
		}
		return (0);
	}

	public int FormatVoteImage(int voteCount)
	{
		return (voteCount * 3);
	}

}
//<!--
//                                <asp:TemplateField HeaderText="所占总票的百分比" ItemStyle-HorizontalAlign="Left" ItemStyle-BorderWidth="1">
//                                    <ItemStyle Width="300px"></ItemStyle>
//                                    <ItemTemplate>
//                                        <asp:Image ID="voteImage" Runat="server" Height="20" Width='<%# FormatVoteImage(FormatVoteCount(DataBinder.Eval(Container.DataItem,"VoteCount").ToString(),100))%>' ImageUrl="Images/vote.gif">
//                                        </asp:Image>
//                                        <%# FormatVoteCount(DataBinder.Eval(Container.DataItem,"VoteCount").ToString(),100)%>
//                                        %
//                                    </ItemTemplate>
//                                </asp:TemplateField>								
//                                <asp:TemplateField HeaderText="票数"  ItemStyle-Width="20%">
//                                    <ItemTemplate>
//                                        <%# DataBinder.Eval(Container.DataItem,"VoteCount") %>
//                                    </ItemTemplate>
//                                </asp:TemplateField> -->
