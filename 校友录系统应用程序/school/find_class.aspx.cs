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
	/// find_class 的摘要说明。
	/// </summary>
	public class find_class : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlSchcity;
		protected System.Web.UI.WebControls.DropDownList ddlSchtype;
		protected System.Web.UI.WebControls.Label lblSchtype;
		protected System.Web.UI.WebControls.TextBox txtSchkey;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Button btnNext1;
		SqlConnection cn;
		SqlCommand cmd;
		SqlDataReader dr;
		string strConn,strSQL;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			if(!Page.IsPostBack)
			{
				ddlSchtype.Items.Add("请选择学校类型");
				ddlSchtype.Items.Add("大 学");
				ddlSchtype.Items.Add("中 学");
				ddlSchtype.Items.Add("中 专");
				ddlSchtype.Items.Add("小 学");
				strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];				
				strSQL="select city_name from city where pro_id="+Page.Request["pid"].ToString();				
				cn=new SqlConnection(strConn);
				cn.Open();
				cmd=new SqlCommand(strSQL,cn);
			
				dr=cmd.ExecuteReader();
				while(dr.Read())
					ddlSchcity.Items.Add(dr["city_name"].ToString());
				cn.Close();
			}

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
			this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNext1_Click(object sender, System.EventArgs e)
		{
			if(ddlSchtype.SelectedIndex==0)
				lblSchtype.Visible=true;
			else
			{
				string P1,P2,P3;
				strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];				
				P1=ddlSchcity.SelectedItem.Text.ToString();
				cn=new SqlConnection(strConn);
				strSQL="select city_id from city where city_name='"+P1+"'";
				cn.Open();
				cmd=new SqlCommand(strSQL,cn);
				dr=cmd.ExecuteReader();
				while(dr.Read())
					P1=dr[0].ToString();
				dr.Close();
				cn.Close();
				P2=ddlSchtype.SelectedIndex.ToString();
				P3=txtSchkey.Text.ToString();				
				Page.Response.Redirect("find_class2.aspx?cid="+P1+"&typ="+P2+"&kywd="+P3+"&pid="+Page.Request["pid"].ToString());
			}
		}
	}
}
