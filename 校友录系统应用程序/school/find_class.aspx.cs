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
	/// find_class ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			if(!Page.IsPostBack)
			{
				ddlSchtype.Items.Add("��ѡ��ѧУ����");
				ddlSchtype.Items.Add("�� ѧ");
				ddlSchtype.Items.Add("�� ѧ");
				ddlSchtype.Items.Add("�� ר");
				ddlSchtype.Items.Add("С ѧ");
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
