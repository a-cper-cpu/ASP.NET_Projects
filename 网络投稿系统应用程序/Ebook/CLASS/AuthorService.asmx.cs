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
	/// AuthorService 的摘要说明。
	/// </summary>
	[WebService(Namespace="http://www.services.net/webservices/")]
	public class AuthorService : System.Web.Services.WebService
	{
		private string ConnectionString;
		public SqlConnection myConnection;
        //公共错误信息
		public string myErrorString;
		public AuthorService()
		{
			//CODEGEN: 该调用是 ASP.NET Web 服务设计器所必需的
			InitializeComponent();
		}

		#region 组件设计器生成的代码
		
		//Web 服务设计器所必需的
		private IContainer components = null;
				
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		// WEB 服务示例
		// HelloWorld() 示例服务返回字符串 Hello World
		// 若要生成，请取消注释下列行，然后保存并生成项目
		// 若要测试此 Web 服务，请按 F5 键

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}
		//连接数据库		
		public void ConnectDB()
		{
			ConnectionString =ConfigurationSettings.AppSettings["ConnectionString"];			
			myConnection = new SqlConnection(ConnectionString);			
			myConnection.Open();							
		}

		[WebMethod]//用户信息
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

		[WebMethod]//用户名是否存在
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

		
		[WebMethod]//加入用户资料
		public bool AuthorUserInsert(string  UserName,string  PassWord,string  Name,string  Card,int Sex,int Age,string Address,int Zipcode,string City,string Country,string Email,string Phone,string Mobile,string Question,string Answer,string Notes)
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string UserPWD_MD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( PassWord,"MD5");

			string myInsertString = "Add_Author '"+UserName+"','"+UserPWD_MD5+"','"+Name+"','"+Card+"',"+Sex.ToString()+","+Age.ToString()+",'"+Address+"','"+Zipcode.ToString()+"','"+City+"','"+Country+"','"+Email+"','"+Phone+"','"+Mobile+"','"+Question+"','"+Answer+"','"+Notes+"'";
			//调用存储过程
			
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

		
		
		[WebMethod]//更新用户资料
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
			//调用存储过程
			
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
		public bool AuthorUserLogin(string  UserName,string  PassWord)//登陆密码认证//用于作者会员登陆
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string UserPWD_MD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( PassWord,"MD5");

			string mySPString = "Author_Login '"+ UserName+"','"+UserPWD_MD5+"'";//调用存储过程
			
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


		[WebMethod]//可用于著者用户信息管理
		public DataSet AuthorInfoDS(string UserName)//输入著者用户名，返回其他字段内容装在一个DataSet内
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


		[WebMethod]//返回问题让人回答
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


		[WebMethod]//判断提示问题的答案是否正确
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
		public string SendPassMail(string fromwho,string Email)//发邮件//产生新密码
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
		public string CreatePWD()//产生6位的密码
		{
			Random rdm = new Random(unchecked((int)DateTime.Now.Ticks));
			string rdmstring = rdm.Next(100000,999999).ToString();
			return rdmstring;
		}


		[WebMethod]
		public bool UpdateAuthorUserPass(string  UserName,string  PassWord)//更新用户密码//把产生的新密码送回数据库
		{
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			string myUpdatePWDString = "Author_UpdatePWD '"+ UserName+"','"+ PassWord+"'";
			//调用存储过程

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


		
		[WebMethod]//提交出版申请单//包括作品出版条件//返回0错，其它为反馈成功的出版单号
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
		public DataSet RequestSheetSelect(int RequestID,string RequestPWD)//出版申请单管理之查询出版申请单，返回一个DataSet
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
		
		}//出版申请单管理之查询出版申请单，返回一个DataSet



		[WebMethod]//把订单状态改成2 or 3 or 4。//申请状态：1/提出，2/发行商同意3/发行不商同意4/作者确认
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
