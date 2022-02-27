namespace student1
{
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
	/// <summary>
	/// speak ��ժҪ˵����
	/// </summary>
	public class speak : System.Web.UI.Page
	{		
		protected System.Web.UI.WebControls.TextBox title;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox name;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox body;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			SqlConnection myConnection = new SqlConnection(sqlconn);
			string sql="select * from info";
			SqlDataAdapter myCommand = new SqlDataAdapter(sql,myConnection);
			DataSet ds = new DataSet();
			myCommand.Fill(ds,"info");
			DataGrid1.DataSource =ds;
			DataGrid1.DataBind();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string TiT;
			string na;
			string xinxi;
			TiT=title.Text;
			na=name.Text;
			xinxi=body.Text;
			string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			SqlConnection myConnection = new SqlConnection(sqlconn);
			string insertQuery="insert into info (title, name, letter) values ('"+TiT+"', '"+na+"', '"+xinxi+"')";		
			SqlCommand cmd = new SqlCommand(insertQuery, myConnection);
			//������
			myConnection.Open();
			//ִ�в������
			cmd.ExecuteNonQuery();
			//�ر����ݿ�����
			myConnection.Close();
			Response.Redirect("speak.aspx");
		}
	}
}
