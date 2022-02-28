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
	/// delinfo ��ժҪ˵����
	/// </summary>
	/// SqlConnection cn;
	
	public class delinfo : System.Web.UI.Page
	{
		SqlConnection cn;
		SqlCommand cmd;		
		SqlDataReader dr;
		string strConn,strSQL;	
		public string strClid;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session.Count==0) Page.Response.Redirect("default.aspx");
			else 
				if(Session["uid"].ToString()=="") Page.Response.Redirect("default.aspx");
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			cn=new SqlConnection(strConn);
			cn.Open();

			strSQL="select class_id from info where info_id="+Page.Request["infoid"].ToString();
			SqlCommand cmd1=new SqlCommand(strSQL,cn);
			dr=cmd1.ExecuteReader();
			while(dr.Read())
				
					strClid=dr["class_id"].ToString();
					dr.Close();
					cn.Close();
				
			dr.Close();
			//��ɾ����Ϣ��־�ֶ���Ϊ1����Ϣ����ʾ
			strConn = ConfigurationSettings.AppSettings["SQLConnectionString"];	
			strSQL="Update info SET del_flag='1' where info_id="+Page.Request["infoid"].ToString();
			cn=new SqlConnection(strConn);
			cn.Open();
			cmd=new SqlCommand(strSQL,cn);
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			cn.Close();			
			Page.Response.Redirect("info.aspx?clid="+strClid);
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
	}
}
