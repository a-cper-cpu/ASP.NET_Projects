using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Configuration;
using System.Web.Security;

namespace Forum
{
	/// <summary>
	/// Forum ��ժҪ˵����
	/// </summary>
	public class Forum:Page
	{
		public string Postuser;
		public HttpCookie readcookie;
		public string Pass;
		public int isubb=1;    
		public int ishtml=0;     
		public int isscript=0; 
		public int isflash=1;  
		public int isimg=1; 
		public string[] arrwordr;
		private SqlConnection  MyConn;
		public string MyConnString =ConfigurationSettings.AppSettings["ConnectionString"];
		public Forum()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		//�����ݿ�
		public  SqlConnection Open()
		{
			MyConn = new SqlConnection(MyConnString);
			MyConn.Open();
			return( MyConn );
		}

		//ִ��SQL��䣬�����ݼ����ص�DataReader��
		public SqlDataReader GetDataReader(string Commandrtring)
		{
			SqlCommand CmdCommand=new SqlCommand(Commandrtring,MyConn);
			SqlDataReader MyDataReader=CmdCommand.ExecuteReader();
			return MyDataReader;
		}
		//ִ��SQL��䣬������ִ�н��
		public int ExecuteSQL(string Commandrtring)
		{
			SqlCommand CmdCommand=new SqlCommand(Commandrtring,MyConn);
			int nAffected=CmdCommand.ExecuteNonQuery();
			return nAffected;
		}
		//����DataSet
		public DataSet  GetDataSet(string Commandrtring, string TableName)
		{	
			SqlDataAdapter adAdapter = new SqlDataAdapter();
			adAdapter.SelectCommand=new SqlCommand(Commandrtring,MyConn);
			DataSet drDataSet=new DataSet();
			adAdapter.Fill(drDataSet,TableName);
			return drDataSet;
		}
		//�ر����ݿ�
		public void Close()
		{
			this.MyConn.Close();
		}

		//����û���Ϣ
		public String AddUser(string UserName, string password, int qq, string sex, 
			string email,  string Sign) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("AddUser", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 20);
			parameterUserName.Value = UserName;
			myCommand.Parameters.Add(parameterUserName);

			SqlParameter parameterPassword = new SqlParameter("@Pass", SqlDbType.NVarChar, 20);
			parameterPassword.Value = password;
			myCommand.Parameters.Add(parameterPassword);
			
			SqlParameter parameterQQ = new SqlParameter("@QQ", SqlDbType.Int, 4);
			parameterQQ.Value = qq;
			myCommand.Parameters.Add(parameterQQ);

			SqlParameter parameterSex = new SqlParameter("@Sex", SqlDbType.VarChar, 2);
			parameterSex.Value = sex;
			myCommand.Parameters.Add(parameterSex);

			SqlParameter parameterEmail = new SqlParameter("@mail", SqlDbType.NVarChar, 50);
			parameterEmail.Value = email;
			myCommand.Parameters.Add(parameterEmail);

			SqlParameter parameterSign = new SqlParameter("@Sign", SqlDbType.NVarChar, 200);
			parameterSign.Value = Sign;
			myCommand.Parameters.Add(parameterSign);		

			SqlParameter parameterID = new SqlParameter("@ID", SqlDbType.Int, 4);
			//ָ���ò����Ǵ洢���̵�OUTPUT����
			parameterID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(parameterID);

			try 
			{
				//�����ݿ�����
				myConnection.Open();
				//�������ݿ����
				myCommand.ExecuteNonQuery();
				//�ر����ݿ�����
				myConnection.Close();

				//ʹ�ô洢���̵������������UserID
				int UserId = (int)parameterID.Value;

				return UserId.ToString();
			}
			catch 
			{
				return String.Empty;
			}
		}

		//��֤�û���Ϣ
		public SqlDataReader UserLogin(string UserName, string password) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("CheckUser", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 20);
			parameterUserName.Value = UserName;
			myCommand.Parameters.Add(parameterUserName);

			SqlParameter parameterPassword = new SqlParameter("@Pass", SqlDbType.NVarChar, 20);
			parameterPassword.Value = password;
			myCommand.Parameters.Add(parameterPassword);
		
			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			return dr;			
		}
		
		//��֤�û���Ϣ��Ψһ��
		public SqlDataReader CheckUserName(string UserName) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("CheckUserName", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 20);
			parameterUserName.Value = UserName;
			myCommand.Parameters.Add(parameterUserName);
	
			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return dr;			
		}

		//��ѯ�û��ĸ�����Ϣ
		public SqlDataReader DisplayUserInfo(string UserName) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("DisplayUserInfo", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 20);
			parameterUserName.Value = UserName;
			myCommand.Parameters.Add(parameterUserName);

			//�����ݿ�����
			myConnection.Open();
			//�������ݿ����
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return dr;			
		}

		public void UserInforModify(string UserName, string password, string email,int sex, int qq, 
			 string Sign) 
		{

			//�������ݿ����Ӻ�����Ķ���
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("UserInforModify", myConnection);

			//ָ��Sql����Ĳ���������ʹ�ô洢����
			myCommand.CommandType = CommandType.StoredProcedure;

			//���洢������Ӳ���
			SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 20);
			parameterUserName.Value = UserName;
			myCommand.Parameters.Add(parameterUserName);

			SqlParameter parameterPassword = new SqlParameter("@Pass", SqlDbType.NVarChar, 20);
			parameterPassword.Value = password;
			myCommand.Parameters.Add(parameterPassword);
			
			SqlParameter parameterQQ = new SqlParameter("@QQ", SqlDbType.Int, 4);
			parameterQQ.Value = qq;
			myCommand.Parameters.Add(parameterQQ);

			SqlParameter parameterSex = new SqlParameter("@Sex", SqlDbType.Int, 4);
			parameterSex.Value = sex;
			myCommand.Parameters.Add(parameterSex);

			SqlParameter parameterEmail = new SqlParameter("@mail", SqlDbType.NVarChar, 50);
			parameterEmail.Value = email;
			myCommand.Parameters.Add(parameterEmail);			

			SqlParameter parameterSign = new SqlParameter("@Sign", SqlDbType.NVarChar, 200);
			parameterSign.Value = Sign;
			myCommand.Parameters.Add(parameterSign);		

			try 
			{
				//�����ݿ�����
				myConnection.Open();
				//�������ݿ����
				myCommand.ExecuteNonQuery();
				//�ر����ݿ�����
				myConnection.Close();

				return;
			}
			catch 
			{
				return;
			}
		}
		public string texttohtml(string chr)
		{
			if(chr==null)
				return "";
			chr=chr.Replace("<","&lt");
			chr=chr.Replace(">","&gt");
			chr=chr.Replace("\n","<br>");
			chr=chr.Replace(" ","&nbsp;");
			return(chr);	
		}
		public string changechr(string chr)
		{
			if(chr==null)
				return "";

			if(isscript==0)
			{
				chr = Regex.Replace(chr,@"<script(?<x>[^\>]*)>(?<y>[^\>]*)\</script\>",@"&lt;script$1&gt;$2&lt;/script&gt;",RegexOptions.IgnoreCase);
			}
			
			if( isubb == 1)
			{
				chr = Regex.Replace(chr,@"\[url=(?<x>[^\]]*)\](?<y>[^\]]*)\[/url\]",@"<a href=$1 target=_blank>$2</a>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[url\](?<x>[^\]]*)\[/url\]",@"<a href=$1 target=_blank>$1</a>",RegexOptions.IgnoreCase);

				chr = Regex.Replace(chr,@"\[email=(?<x>[^\]]*)\](?<y>[^\]]*)\[/email\]",@"<a href=$1>$2</a>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[email\](?<x>[^\]]*)\[/email\]",@"<a href=mailto:$1>$1</a>",RegexOptions.IgnoreCase);

				if(isflash==1)
				{
					chr = Regex.Replace(chr,@"\[flash](?<x>[^\]]*)\[/flash]",@"<OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=4,0,2,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width=500 height=400><PARAM NAME=movie VALUE=""$1""><PARAM NAME=quality VALUE=high><embed src=""$1"" quality=high pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width=500 height=400>$1</embed></OBJECT>",RegexOptions.IgnoreCase);
				}
				if(isimg==1)
				{
					chr = Regex.Replace(chr,@"\[img](?<x>[^\]]*)\[/img]",@"<IMG SRC=""$1"" border=0   onload='javascript:if(this.width>screen.width-333)this.width=screen.width-333'  >",RegexOptions.IgnoreCase);
				}
				chr = Regex.Replace(chr,@"\[color=(?<x>[^\]]*)\](?<y>[^\]]*)\[/color\]",@"<font color=$1>$2</font>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[face=(?<x>[^\]]*)\](?<y>[^\]]*)\[/face\]",@"<font face=$1>$2</font>",RegexOptions.IgnoreCase);

				chr = Regex.Replace(chr,@"\[size=1\](?<x>[^\]]*)\[/size\]",@"<font size=1>$1</font>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[size=2\](?<x>[^\]]*)\[/size\]",@"<font size=2>$1</font>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[size=3\](?<x>[^\]]*)\[/size\]",@"<font size=3>$1</font>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[size=4\](?<x>[^\]]*)\[/size\]",@"<font size=4>$1</font>",RegexOptions.IgnoreCase);

				chr = Regex.Replace(chr,@"\[align=(?<x>[^\]]*)\](?<y>[^\]]*)\[/align\]",@"<align=$1>$2</align>",RegexOptions.IgnoreCase);

				chr = Regex.Replace(chr,@"\[fly](?<x>[^\]]*)\[/fly]",@"<marquee width=90% behavior=alternate scrollamount=3>$1</marquee>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[move](?<x>[^\]]*)\[/move]",@"<marquee scrollamount=3>$1</marquee>",RegexOptions.IgnoreCase);

				chr = Regex.Replace(chr,@"\[glow=(?<x>[^\]]*),(?<y>[^\]]*),(?<z>[^\]]*)\](?<w>[^\]]*)\[/glow\]",@"<table width=$1 style='filter:glow(color=$2, strength=$3)'>$4</table>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[shadow=(?<x>[^\]]*),(?<y>[^\]]*),(?<z>[^\]]*)\](?<w>[^\]]*)\[/shadow\]",@"<table width=$1 style='filter:shadow(color=$2, strength=$3)'>$4</table>",RegexOptions.IgnoreCase);

				chr = Regex.Replace(chr,@"\[b\](?<x>[^\]]*)\[/b\]",@"<b>$1</b>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[i\](?<x>[^\]]*)\[/i\]",@"<i>$1</i>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[u\](?<x>[^\]]*)\[/u\]",@"<u>$1</u>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[code\](?<x>[^\]]*)\[/code\]",@"<pre id=code><font size=1 face='Verdana, Arial' id=code>$1</font id=code></pre id=code>",RegexOptions.IgnoreCase);

				chr = Regex.Replace(chr,@"\[list\](?<x>[^\]]*)\[/list\]",@"<ul>$1</ul>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[list=1\](?<x>[^\]]*)\[/list\]",@"<ol type=1>$1</ol id=1>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[list=a\](?<x>[^\]]*)\[/list\]",@"<ol type=a>$1</ol id=a>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[\*\](?<x>[^\]]*)\[/\*\]",@"<li>$1</li>",RegexOptions.IgnoreCase);
				chr = Regex.Replace(chr,@"\[quote](?<x>.*)\[/quote]",@"<center>���� ���������� ����<table border='1' width='80%' cellpadding='10' cellspacing='0' style='font-size: 9pt'><tr><td>$1</td></tr></table>���� ������� ����</center>",RegexOptions.IgnoreCase);
			}
			return(chr);
		}

		public string[] splitstring(string oldrtring)
		{
			if (oldrtring!="")
			{
				char[] ch = {'|'};
				arrwordr=oldrtring.Split(ch);
				return(arrwordr);
			}
			else 
			{
				return(null);    
			}
		}

		public string adminck()
		{
			
			if ( Session["au"] == "yes" )
			{
				return("yes"); 
			}
			else 
			{
				return("Wrong");      
			}
		}
	}
}
