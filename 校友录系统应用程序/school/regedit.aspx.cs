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
	/// regedit ��ժҪ˵����
	/// </summary>
	public class regedit : System.Web.UI.Page
	{
		//�����ļ���ʹ�õı�����������
		protected System.Web.UI.WebControls.TextBox txtAccount;
		protected System.Web.UI.WebControls.Panel step2;
		protected System.Web.UI.WebControls.TextBox txtUname;		
		protected System.Web.UI.WebControls.RadioButtonList rltSex;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.DropDownList ddlDay;
		protected System.Web.UI.WebControls.TextBox txtUjob;
		protected System.Web.UI.WebControls.TextBox txtUtel1;
		protected System.Web.UI.WebControls.TextBox txtUtel2;
		protected System.Web.UI.WebControls.TextBox txtUtel3;
		protected System.Web.UI.WebControls.TextBox txtUpager;
		protected System.Web.UI.WebControls.TextBox txtUaddr;
		protected System.Web.UI.WebControls.TextBox txtUemail;		
				
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.HtmlControls.HtmlGenericControl span1;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnReturn;		
		protected System.Web.UI.WebControls.Panel step1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;

		private ArrayList alYear;
		private ArrayList alMonth;
		private ArrayList alDay;
		int i;

		//���ݿ������ر���	
		protected System.Web.UI.WebControls.TextBox txtUzip;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label lblOK;
		protected System.Web.UI.WebControls.Label lblStep2;
		protected System.Web.UI.WebControls.Calendar Cal1;		
		protected System.Web.UI.WebControls.TextBox txtUpwd;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox txtUpwd2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;		
		protected System.Web.UI.WebControls.Label lblPwd;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				
				step1.Visible=true;				
				step2.Visible=false;

				alYear=new ArrayList();				
				alMonth=new ArrayList();				
				alDay=new ArrayList();				

				for(i=1972;i<1989;i++)
					alYear.Add(i.ToString());

				for(i=1;i<=12;i++)
					alMonth.Add(i.ToString());

				for(i=1;i<32;i++)
					alDay.Add(i.ToString());

				ddlYear.DataSource=alYear;
				ddlYear.DataBind();

				ddlMonth.DataSource=alMonth;
				ddlMonth.DataBind();

				ddlDay.DataSource=alDay;
				ddlDay.DataBind();					
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.ddlYear.SelectedIndexChanged += new System.EventHandler(this.Date_SelectIndexChanged);
			this.ddlMonth.SelectedIndexChanged += new System.EventHandler(this.Date_SelectIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
				
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{				
				//�������ݿ�����
				string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
				SqlConnection myConnection = new SqlConnection(sqlconn);				
				string sql="select * from userreg where login='"+txtAccount.Text.ToString()+"'";				
				myConnection.Open();
				
				SqlCommand cmd = new SqlCommand(sql, myConnection);
						
				SqlDataReader dr=cmd.ExecuteReader();
				//�ж��û����Ƿ��Ѿ�����
				if(dr.Read())
				{
					lblStep2.Text="��������û����Ѿ����ڣ�����ѡ��һ�����������֣�";
					myConnection.Close();								
				}
				else
				{
					//������ʾ�û������ע����Ϣ
					myConnection.Close();
					lblPwd.Text=txtUpwd.Text.ToString();
					step1.Visible=false;				
					step2.Visible=true;
					span1.InnerHtml="���������Ϣ�ǣ�"+"<br>";						
					span1.InnerHtml+="��¼����"+txtAccount.Text.ToString()+"<br>";
					span1.InnerHtml+="������"+txtUname.Text.ToString()+"<br>";
					span1.InnerHtml+="�Ա�"+rltSex.SelectedItem.Text.ToString()+"<br>";
					span1.InnerHtml+="���գ�"+ddlYear.SelectedItem.Text.ToString()+"��"+ddlMonth.SelectedItem.Text.ToString()+"��"+ddlDay.SelectedItem.Text.ToString()+"��"+"<br>";
					span1.InnerHtml+="E_mail��"+txtUemail.Text.ToString()+"<br>";				
					span1.InnerHtml+="�칫�绰��"+txtUtel1.Text.ToString()+"<br>";
					span1.InnerHtml+="��ͥ�绰��"+txtUtel2.Text.ToString()+"<br>";
					span1.InnerHtml+="�ƶ��绰��"+txtUtel3.Text.ToString()+"<br>";	
					span1.InnerHtml+="������λ��"+txtUjob.Text.ToString()+"<br>";
					span1.InnerHtml+="ͨѶ��ַ��"+txtUaddr.Text.ToString()+"<br>";
					span1.InnerHtml+="�������룺"+txtUzip.Text.ToString()+"<br>";
				}																
			}	
		}
		//�����桱��ťӦ�ù��̣����û���Ϣ��ŵ����ݱ���
		public void btnSave_Click(object sender, System.EventArgs e)
		{

			if(Page.IsValid)
			{
				string rs="";
				string sqlconn = ConfigurationSettings.AppSettings["SQLConnectionString"];
				SqlConnection myConnection = new SqlConnection(sqlconn);
				myConnection.Open();
				string sql="select max(id)+1,count(*) from userreg";
				SqlCommand cmd1 = new SqlCommand(sql, myConnection);				
				SqlDataReader myReader;
				myReader = cmd1.ExecuteReader();								
				while (myReader.Read())
				{	
					if(myReader[1].ToString()!="0")
					{
						rs += myReader[0].ToString();
					}
					else
					{
						rs="1";
					}
					
				}	
				string strSQL="";
				strSQL="INSERT INTO userreg(id,name,login,password,sex,bth,regdate,work_tell,home_tell,mobile_tell,address,yb,email,job) VALUES('";
				strSQL+=rs+"','";
				strSQL+=txtUname.Text.ToString()+"','";
				strSQL+=txtAccount.Text.ToString()+"','";
				strSQL+=lblPwd.Text.ToString()+"','";
				strSQL+=rltSex.SelectedItem.Text.ToString()+"','";
				strSQL+=ddlYear.SelectedItem.Text.ToString()+"-"+ddlMonth.SelectedItem.Text.ToString()+"-"+ddlDay.SelectedItem.Text.ToString()+"','";
				strSQL+=DateTime.Today.ToString()+"','";
				strSQL+=txtUtel1.Text.ToString()+"','";
				strSQL+=txtUtel2.Text.ToString()+"','";
				strSQL+=txtUtel3.Text.ToString()+"','";
				strSQL+=txtUaddr.Text.ToString()+"','";
				strSQL+=txtUzip.Text.ToString()+"','";
				strSQL+=txtUemail.Text.ToString()+"','";
				strSQL+=txtUjob.Text.ToString()+"')";								
				
				myReader.Close();
				SqlCommand cmd2 = new SqlCommand(strSQL, myConnection);
				cmd2.ExecuteNonQuery();		
				strSQL="select id from userreg where login='"+txtAccount.Text.ToString()+"'";												
				SqlCommand cmd3 = new SqlCommand(strSQL, myConnection);							
				SqlDataReader dr=cmd3.ExecuteReader();
				while(dr.Read())
				{
					Session["uid"]=dr["id"];
				}
				dr.Close();
				myConnection.Close();				                
				Page.Response.Redirect("school.aspx");
			}			
		}
		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			
			step1.Visible=true;			
			step2.Visible=false;
		
		}
		//�������ڵ���ʾ
		private void Date_SelectIndexChanged(object sender,System.EventArgs e)
		{
			int[] numbers = {31,28, 31, 30, 31,30,31,31,30,31,30,31};
			if((Convert.ToInt32(ddlYear.SelectedItem.Text.ToString())%4)==0)
				numbers[1]=29;

			alDay=new ArrayList();
			for(i=1;i<=numbers[Convert.ToInt32(ddlMonth.SelectedItem.Text.ToString())-1];i++)
				alDay.Add(i.ToString());
			ddlDay.DataSource=alDay;
			ddlDay.DataBind();
		}
	}
}
