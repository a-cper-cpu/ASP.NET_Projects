using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Mail;
using System.Data.SqlClient;
using System.Configuration;

namespace Ebook
{
	/// <summary>
	/// AuthorService ��ժҪ˵����
	/// </summary>
	[WebService(Namespace="http://www.services.net/webservices/")]
	public class AuthorService : System.Web.Services.WebService
	{
		private string ConnectionString;
		public SqlConnection myConnection;
        //����������Ϣ
		public string myErrorString;
		public AuthorService()
		{
			//CODEGEN: �õ����� ASP.NET Web ����������������
			InitializeComponent();
		}

		#region �����������ɵĴ���
		
		//Web ����������������
		private IContainer components = null;
				
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB ����ʾ��
		// HelloWorld() ʾ�����񷵻��ַ��� Hello World
		// ��Ҫ���ɣ���ȡ��ע�������У�Ȼ�󱣴沢������Ŀ
		// ��Ҫ���Դ� Web �����밴 F5 ��

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}
		//�������ݿ�		
		public void ConnectDB()
		{
			ConnectionString =ConfigurationSettings.AppSettings["ConnectionString"];			
			myConnection = new SqlConnection(ConnectionString);			
			myConnection.Open();							
		}

		[WebMethod]//�û���Ϣ
		public DataSet AuthorUserInfo(string UserName,string UserPWD,string TableName,string NameField,string PWDField)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string UserPWD_MD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(UserPWD,"MD5");

			string myQueryString = "SELECT * FROM "+TableName+" where "+NameField+"='"+UserName+"' and "+PWDField+"='"+UserPWD_MD5+"'";

			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}					
		}

		[WebMethod]//�û����Ƿ����
		public bool AuthorUserNameUsed(string UserName,string TableName,string FieldName)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryString = "Select * from "+TableName+" where "+FieldName+" = '" + UserName + "'";

			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
					if(myReader.Read())
					{
						myReader.Close();
						myConnection.Close();
						return true;
					}
					else
					{
						myReader.Close();
						myConnection.Close();
						return false;
					}
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					return false;
				}			
		}

		
		[WebMethod]//�����û�����
		public bool AuthorUserInsert(string  UserName,string  PassWord,string  Name,string  Card,int Sex,int Age,string Address,int Zipcode,string City,string Country,string Email,string Phone,string Mobile,string Question,string Answer,string Notes)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string UserPWD_MD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( PassWord,"MD5");

			string myInsertString = "Add_Author '"+UserName+"','"+UserPWD_MD5+"','"+Name+"','"+Card+"',"+Sex.ToString()+","+Age.ToString()+",'"+Address+"','"+Zipcode.ToString()+"','"+City+"','"+Country+"','"+Email+"','"+Phone+"','"+Mobile+"','"+Question+"','"+Answer+"','"+Notes+"'";
			//���ô洢����
			
				SqlCommand myCommand = new SqlCommand(myInsertString,myConnection);

				try
				{
					myCommand.ExecuteNonQuery();

					myConnection.Close();

					return true;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					return false;
				}			
			
		}

		
		
		[WebMethod]//�����û�����
		public bool AuthorUserUpdate(string  UserName,string  PassWord,string  Name,string Card,int Sex,int Age,string Address,int Zipcode,string City,string Country,string Email,string Phone,string Mobile,string Question,string Answer,string Notes)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string UserPWD_MD5;
			if ( PassWord == "")
			{
				UserPWD_MD5 = "";
			}
			else
			{
				UserPWD_MD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( PassWord,"MD5");
			}

			string myUpdateString = "Author_Update '"+ UserName+"','"+UserPWD_MD5+"','"+ Name+"','"+Card+"',"+Sex.ToString()+","+Age.ToString()+",'"+Address+"','"+Zipcode.ToString()+"','"+City+"','"+Country+"','"+Email+"','"+Phone+"','"+Mobile+"','"+Question+"','"+Answer+"','"+Notes+"'";
			//���ô洢����
			
				SqlCommand myCommand = new SqlCommand(myUpdateString,myConnection);
				try
				{
					myCommand.ExecuteNonQuery();

					myConnection.Close();

					return true;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					return false;
				}			
		}


		
		[WebMethod]
		public bool AuthorUserLogin(string  UserName,string  PassWord)//��½������֤//�������߻�Ա��½
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string UserPWD_MD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( PassWord,"MD5");

			string mySPString = "Author_Login '"+ UserName+"','"+UserPWD_MD5+"'";//���ô洢����
			
				SqlCommand myCommand = new SqlCommand(mySPString,myConnection);
				try
				{
					SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

					if(myReader.Read())
					{
						myReader.Close();
						myConnection.Close();
						return true;
					}
					else
					{
						myReader.Close();
						myConnection.Close();
						return false;
					}
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;
					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					return false;
				}
			
		}	


		[WebMethod]//�����������û���Ϣ����
		public DataSet AuthorInfoDS(string UserName)//���������û��������������ֶ�����װ��һ��DataSet��
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryStr = "Search_Authorinfo '" + UserName + "'";

			
				SqlCommand myCommand = new SqlCommand(myQueryStr,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}
			
		}


		[WebMethod]//�����������˻ش�
		public string GetQuestion(string UserName)
		{
			string QuestionTemp;
			try
			{
				QuestionTemp = AuthorInfoDS(UserName).Tables[0].Rows[0].ItemArray[14].ToString();
			}
			catch
			{
				QuestionTemp = "000";
			}
			return QuestionTemp;
		}


		[WebMethod]//�ж���ʾ����Ĵ��Ƿ���ȷ
		public bool IsAnswerRight(string UserName,string Answer)
		{
			DataSet myds = new DataSet();
			myds = AuthorInfoDS(UserName);
			if (Answer == myds.Tables[0].Rows[0].ItemArray[15].ToString())
			{
				return true;
			}
			else
			{
				return false;
			};
		}


		[WebMethod]
		public string SendPassMail(string fromwho,string Email)//���ʼ�//����������
		{
			MailMessage sendmail = new MailMessage();			//send a email
			sendmail.To = Email; 
			sendmail.From = fromwho;
			sendmail.BodyFormat = MailFormat.Text;
			Random rdm1 = new
				Random(unchecked((int)DateTime.Now.Ticks));   //random a password
			Random rdm2 = new
				Random();			
			string rdmstring = rdm1.Next(1000,9999).ToString() + rdm2.Next(10,99).ToString();
			sendmail.Body = " Your New Password is:" + rdmstring +"\n Please Change it when you login in!";
			SmtpMail.Send(sendmail);
			return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(rdmstring,"MD5");
		}


		[WebMethod]
		public bool SendMail(string FromWho,string ToWho,string Content)
		{
			try
			{
				MailMessage sendmail = new MailMessage();			//send a email
				sendmail.To = ToWho; 
				sendmail.From = FromWho;
				sendmail.BodyFormat = MailFormat.Text;
				sendmail.Body = Content;
				SmtpMail.Send(sendmail);
				return true;
			}
			catch
			{
				return false;
			}
		}


		[WebMethod]
		public string CreatePWD()//����6λ������
		{
			Random rdm = new Random(unchecked((int)DateTime.Now.Ticks));
			string rdmstring = rdm.Next(100000,999999).ToString();
			return rdmstring;
		}


		[WebMethod]
		public bool UpdateAuthorUserPass(string  UserName,string  PassWord)//�����û�����//�Ѳ������������ͻ����ݿ�
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myUpdatePWDString = "Author_UpdatePWD '"+ UserName+"','"+ PassWord+"'";
			//���ô洢����

			if  (AuthorUserNameUsed( UserName,"Author"," UserName") == true)
			{
				
					SqlCommand myCommand = new SqlCommand(myUpdatePWDString,myConnection);
					try
					{
						myCommand.ExecuteNonQuery();

						myConnection.Close();

						return true;
					}//try
					catch (SqlException myException) 
					{
						SqlErrorCollection myErrors = myException.Errors;

						for (int i=0; i < myErrors.Count; i++) 
						{	
							myErrorString = "Index #" + i + "\n" +
								"Error: " + myErrors[i].ToString() + "\n";
						}
						return false;
					}
				
			}
			else
			{
				return false;
			}
		}


		
		[WebMethod]//�ύ�������뵥//������Ʒ��������//����0������Ϊ�����ɹ��ĳ��浥��
		public string AddRequest(string  UserName,string Title,string EbookDescription,string file_path,string ApplicationFormContent,string RamdonPassword,string Note)
		{
			//string RamdonPassword = CreatePWD();
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myInsertString = "Add_Request '"+UserName+"','"+Title+"','"+EbookDescription+"','"+file_path+"','"+ApplicationFormContent+"',1,'"+RamdonPassword+"','"+Note+"'";

			
				try 
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();

					myAdapter.SelectCommand=new SqlCommand(myInsertString,myConnection);

					DataSet ds = new DataSet();

					myAdapter.Fill(ds);

					string ApplySheetID = ds.Tables[0].Rows[0][0].ToString ();

					myConnection.Close();

					return ApplySheetID;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}

					return "0";
				}//catch
			
		}

		[WebMethod]//Update Application Form
		public bool UpdateRequest(string RequestID,string BookTitle,string EbookDescription,string ApplicationContent,string Notes,string FileName)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myUpdateString = "Update_Request_Content "+RequestID+",'"+BookTitle+"','"+EbookDescription+"','"+ApplicationContent+"','"+Notes+"'";

			
				SqlCommand myCommand = new SqlCommand(myUpdateString,myConnection);

				try 
				{
					myCommand.ExecuteNonQuery();

					myConnection.Close();

					return true;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}

					return false;
				}//catch			
		}//Update Application Form


		[WebMethod]//RequestID RequestPWD
		public DataSet RequestSheetSelect(int RequestID,string RequestPWD)//�������뵥����֮��ѯ�������뵥������һ��DataSet
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string RequestIDTemp = "";
			try
			{
				RequestIDTemp = RequestID.ToString();
			}
			catch
			{
				//Input RequestID Error!
			}
			string myQueryString =  "Request_Research " + RequestIDTemp + ",'" + RequestPWD + "'";

			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();

					myAdapter.SelectCommand = myCommand;

					DataSet ds = new DataSet();

					myAdapter.Fill(ds);

					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}//catch
		
		}//�������뵥����֮��ѯ�������뵥������һ��DataSet



		[WebMethod]//�Ѷ���״̬�ĳ�2 or 3 or 4��//����״̬��1/�����2/������ͬ��3/���в���ͬ��4/����ȷ��
		public bool UpdateRequestStatus(string RequestID,int StatusValue)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			try
			{
				StatusValue.ToString();
			}
			catch
			{
				return false;
			}

			if ((StatusValue<2) || (StatusValue>4))
				return false;

			string myUpdateString = "Update_Request_Status " + RequestID + "," + StatusValue.ToString();

			
				SqlCommand myCommand = new SqlCommand(myUpdateString,myConnection);
				try 
				{
					myCommand.ExecuteNonQuery();
					myConnection.Close();
					return true;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}

					return false;
				}//catch			
		}		


		[WebMethod]
		public DataSet SearchRequest(string Author_UserName)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryString = "Request_ByUserName '" +Author_UserName+"'";
			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}//catch
					
		}

		[WebMethod]
		public DataSet SearchAllRequest()
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryString = "Search_Request";

			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}//catch			
		}

		


		[WebMethod]
		public DataSet AE_Status1(string Username)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryString = "AE_Status1 '"+Username+"'";

			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}//catch			
			
		}

		[WebMethod]
		public DataSet AE_Status2(string Username)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryString = "AE_Status2 '"+Username+"'";

			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}//catch			
		}

		[WebMethod]
		public DataSet AE_Status3(string Username)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryString = "AE_Status3 '"+Username+"'";
			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}//catch			
		}

		[WebMethod]
		public DataSet AE_Status4(string Username)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myQueryString = "AE_Status4 '"+Username+"'";
			
				SqlCommand myCommand = new SqlCommand(myQueryString,myConnection);

				try
				{
					SqlDataAdapter myAdapter = new SqlDataAdapter();
					myAdapter.SelectCommand = myCommand;
					DataSet ds = new DataSet();
					myAdapter.Fill(ds);
					myConnection.Close();

					return ds;
				}
				catch (SqlException myException) 
				{
					SqlErrorCollection myErrors = myException.Errors;

					for (int i=0; i < myErrors.Count; i++) 
					{	
						myErrorString = "Index #" + i + "\n" +
							"Error: " + myErrors[i].ToString() + "\n";
					}
					DataSet ds = new DataSet();
					return ds;
				}//catch			
		}		
	}
}
