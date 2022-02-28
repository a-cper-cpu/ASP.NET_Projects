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
using System.Configuration;

namespace school
{
	/// <summary>
	/// editinfo 的摘要说明。
	/// </summary>
	public class editinfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtTheme;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtContent;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label lblName;		
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnReturn;
		SqlConnection cn;
		SqlCommand cmd;
		SqlDataReader dr;		
		string strConn,strSQL;
		public string strClid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			
			
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];					
			cn=new SqlConnection(strConn);
			cn.Open();
			strSQL="select info.id,class.admin1,class.admin2,class.admin3,info.class_id from info,class where class.class_id=(select class_id from info where info_id="+Page.Request["infoid"].ToString()+") and info_id="+Page.Request["infoid"].ToString();
			cmd=new SqlCommand(strSQL,cn);
			dr=cmd.ExecuteReader();
			while(dr.Read())
				if(!(Session["uid"].ToString()==dr[0].ToString()|Session["uid"].ToString()==dr[1].ToString()|Session["uid"].ToString()==dr[2].ToString()))
				{
					strClid=dr["class_id"].ToString();
					dr.Close();
					cn.Close();
					Page.Response.Redirect("board.aspx?clid="+strClid);					
				}
			dr.Close();

			strSQL="select class_id from info where info_id="+Page.Request["infoid"].ToString();
			cmd=new SqlCommand(strSQL,cn);
			dr=cmd.ExecuteReader();
			while(dr.Read())
				strClid=dr[0].ToString();
			dr.Close();
			


			strSQL="select info_title,info_cnt,name from info,userreg where userreg.id=(select id from info where info_id="+Page.Request["infoid"].ToString();
			strSQL+=") and info_id="+Page.Request["infoid"].ToString();	
			cmd=new SqlCommand(strSQL,cn);
			dr=cmd.ExecuteReader();
			if(!Page.IsPostBack)
				while(dr.Read())
				{
					txtTheme.Text=dr[0].ToString();
					txtContent.Text=dr[1].ToString();
					lblName.Text=dr[2].ToString();
					
				
				}
			dr.Close();
			cn.Close();
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			strSQL="Update info SET info_title='"+txtTheme.Text;
			strSQL+="',info_cnt='"+txtContent.Text;
			strSQL+="',editer="+Session["uid"].ToString();
			strSQL+=" where info_id="+Page.Request["infoid"].ToString();
			cn=new SqlConnection(strConn);
			cn.Open();
			cmd=new SqlCommand(strSQL,cn);
			cmd.ExecuteNonQuery();
			cmd.Dispose();			
			cn.Close();	
			Page.Response.Redirect("info.aspx?clid="+strClid);
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("info.aspx?clid="+strClid);
		}
	}
}
