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
	/// speak 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
			string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
			SqlConnection myConnection = new SqlConnection(sqlconn);
			string sql="select * from info";
			SqlDataAdapter myCommand = new SqlDataAdapter(sql,myConnection);
			DataSet ds = new DataSet();
			myCommand.Fill(ds,"info");
			DataGrid1.DataSource =ds;
			DataGrid1.DataBind();
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
			//打开连接
			myConnection.Open();
			//执行插入操作
			cmd.ExecuteNonQuery();
			//关闭数据库连接
			myConnection.Close();
			Response.Redirect("speak.aspx");
		}
	}
}
