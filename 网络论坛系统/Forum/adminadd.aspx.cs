using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace Forum
{
	/// <summary>
	/// adminadd ��ժҪ˵����
	/// </summary>
	public class adminadd : System.Web.UI.Page
	{
		public TimeSpan Timesp ;
		public SqlDataReader dr;
		public String Beg;
		public string sqlstring;
		public string LastFid;
		public SqlConnection MyConn;
		public DateTime StartTime ;
		public DateTime StopTime ;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (Request.QueryString["Beg"] == null)
			{
				sqlstring = "Select TopicTotal,id,Begin1,1End1,TopicName,TopicDes,Des,Toastmaster,ReplyTotal  from  ForumInform order by Begin1  asc ";
			}
			else 
			{
				Beg=Request.QueryString["Beg"].ToString();
				sqlstring = "Select TopicTotal,id,Begin1,End1,TopicName,TopicDes,Des,Toastmaster,ReplyTotal  from  ForumInform where Begin1="+Beg+" order by Begin1  asc ";
			}
			DateTime now = DateTime.Now;
			StartTime = DateTime.Now;
			//��������
			Forum ForumDBO = new Forum();
			MyConn=ForumDBO.Open();
			if (ForumDBO.adminck() == "Wrong")
			{
				Response.Redirect("Exceptions.aspx");
			}
			SqlCommand com_TopicTotal = new SqlCommand(sqlstring,MyConn);
			dr = com_TopicTotal.ExecuteReader();
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public void display()
		{
			int Beg;
			int End;
			int n = 0;
			String TopicName;
			String TopicDes;
			
			String Toastmaster;
			String ReplyTotal;
			String TopicTotal;
			String des;
			while(dr.Read())
			{
				Beg = (int)dr["Begin1"];
				End = (int)dr["End1"];
				TopicName = dr["TopicName"].ToString();
				TopicDes = dr["TopicDes"].ToString();				
				Toastmaster = dr["Toastmaster"].ToString();
				ReplyTotal = dr["ReplyTotal"].ToString();
				des = dr["des"].ToString();
				TopicTotal = dr["TopicTotal"].ToString();
				LastFid = dr["Begin1"].ToString();
				if (n == Beg)
				{
					Response.Write("<tr ><td width='5%'  align=center></td><td colspan=2>");
					Response.Write("<a href='Thread.aspx?Beg="+Beg.ToString()+"&End="+End.ToString()+"&page=1"+"'><b>1"+TopicDes+"</b></a><br>");
					Response.Write("</td></tr>");           
				}
				else 
				{
					Response.Write("<tr ><td  colspan=3 bgcolor=#E8F3F9 ><b>"+TopicName+"</b></a><a href='Adminattribu.aspx?action=addclass1&Beg="+Beg+"&TopicName="+TopicDes+"'><font color=red>  ��Ӱ��</font></a></td></tr>");
					Response.Write("<tr ><td width='5%'  align=center></td><td colspan=2>");
					Response.Write("<a href='Thread.aspx?Beg="+Beg.ToString()+"&End="+End.ToString()+"&page=1"+"'><b>"+TopicDes+"</b></a><br>");
					Response.Write("</td></tr>");
					n =  Beg;  
				}
			}
			dr.Close();
			StopTime = DateTime.Now;
			Timesp = StopTime-StartTime;
			MyConn.Close();
		}
	}
}
