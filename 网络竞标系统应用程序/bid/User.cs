using System;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Bid
{
	/// <summary>
	/// user 的摘要说明。
	/// </summary>
	/// 
	public class UserDetails
{
	public string Name;
	public string login;
	public string Email;
	public string Password;
	public string Address1;
	public string Address2;
	public string City;
	public string State;
	public string yb;
	public string Country;
	public Char Active;
	public string LastLogin;
	public Int32 user_id;
}
	public class user
	{
		public user()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public UserDetails GetuserDetails(string strEmail)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_user_sel", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmEmailID = new SqlParameter("@email", SqlDbType.VarChar, 255);
			prmEmailID.Value = strEmail;
			myCommand.Parameters.Add(prmEmailID);

			SqlParameter prmName = new SqlParameter("@Name", SqlDbType.VarChar, 255);
			prmName.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmName);

			SqlParameter prmlogin = new SqlParameter("@login", SqlDbType.VarChar, 255);
			prmlogin.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmlogin);

			SqlParameter prmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 255);
			prmPassword.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmPassword);

			SqlParameter prmAdd1 = new SqlParameter("@add1", SqlDbType.VarChar, 255);
			prmAdd1.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmAdd1);

			SqlParameter prmAdd2 = new SqlParameter("@add2", SqlDbType.VarChar, 255);
			prmAdd2.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmAdd2);

			SqlParameter prmCity = new SqlParameter("@City", SqlDbType.VarChar, 255);
			prmCity.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmCity);

			SqlParameter prmState = new SqlParameter("@state", SqlDbType.VarChar, 255);
			prmState.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmState);

			SqlParameter prmZip = new SqlParameter("@zip", SqlDbType.VarChar, 10);
			prmZip.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmZip);

			SqlParameter prmCountry = new SqlParameter("@country", SqlDbType.VarChar, 255);
			prmCountry.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmCountry);

			SqlParameter prmActive = new SqlParameter("@active", SqlDbType.Char, 1);
			prmActive.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmActive);

			SqlParameter prmLastLogin = new SqlParameter("@lastlogin", SqlDbType.DateTime);
			prmLastLogin.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmLastLogin);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			// Create CustomerDetails Struct
			UserDetails myuserDetails = new UserDetails();
			myuserDetails.Name = prmName.Value.ToString();
			myuserDetails.login = prmlogin.Value.ToString();
			myuserDetails.Name = prmName.Value.ToString();
			myuserDetails.Password = prmPassword.Value.ToString();
			myuserDetails.Address1 = prmAdd1.Value.ToString();
			myuserDetails.Address2 = prmAdd2.Value.ToString();
			myuserDetails.City = prmCity.Value.ToString();
			myuserDetails.State = prmState.Value.ToString();
			myuserDetails.yb = prmZip.Value.ToString();
			myuserDetails.Country = prmCountry.Value.ToString();
			myuserDetails.Active = Convert.ToChar(prmActive.Value);
			myuserDetails.LastLogin = prmLastLogin.Value.ToString();

			return myuserDetails;
		}

	
		public string AddCustomer(string name
			, string login
			, string email
			, string password
			, string add1
			, string add2
			, string city
			, string state
			, string zip
			, string country)
		{
			// Create Instance of Connection and Command Object		
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_user_isp", myConnection);
			//HttpContext.Current.Trace.Write("foo:" + ConfigurationSettings.AppSettings["ConnectionString"]);
			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmEmail = new SqlParameter("@email", SqlDbType.VarChar, 255);
			prmEmail.Value = email;
			myCommand.Parameters.Add(prmEmail);

			SqlParameter prmlogin = new SqlParameter("@login", SqlDbType.VarChar, 255);
			prmlogin.Value = login;
			myCommand.Parameters.Add(prmlogin);

			SqlParameter prmname = new SqlParameter("@name", SqlDbType.VarChar, 255);
			prmname.Value = name;
			myCommand.Parameters.Add(prmname);

			SqlParameter prmadd1 = new SqlParameter("@add1", SqlDbType.VarChar, 255);
			prmadd1.Value = add1;
			myCommand.Parameters.Add(prmadd1);

			SqlParameter prmadd2 = new SqlParameter("@add2", SqlDbType.VarChar, 255);
			prmadd2.Value = add2;
			myCommand.Parameters.Add(prmadd2);

			SqlParameter prmcity = new SqlParameter("@city", SqlDbType.VarChar, 255);
			prmcity.Value = city;
			myCommand.Parameters.Add(prmcity);

			SqlParameter prmstate = new SqlParameter("@state", SqlDbType.VarChar, 255);
			prmstate.Value = state;
			myCommand.Parameters.Add(prmstate);

			SqlParameter prmzip = new SqlParameter("@zip", SqlDbType.VarChar, 10);
			prmzip.Value = zip;
			myCommand.Parameters.Add(prmzip);

			SqlParameter prmcountry = new SqlParameter("@country", SqlDbType.VarChar, 255);
			prmcountry.Value = country;
			myCommand.Parameters.Add(prmcountry);

			SqlParameter prmuserID = new SqlParameter("@userid", SqlDbType.BigInt);
			prmuserID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmuserID);

			SqlParameter prmpwd = new SqlParameter("@pwd", SqlDbType.VarChar, 255);
			prmpwd.Value = password;
			myCommand.Parameters.Add(prmpwd);

			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				return prmuserID.Value.ToString();
			}
			catch (SqlException SQLexc)
			{
				return SQLexc.ToString();
			}
		}
		public String ModifyCustomer(
			  string name
			, string login
			, string email
			, string password
			, string add1
			, string add2
			, string city
			, string state
			, string zip
			, string country)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_user_usp", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmEmail = new SqlParameter("@email", SqlDbType.VarChar, 255);
			prmEmail.Value = email;
			myCommand.Parameters.Add(prmEmail);

			SqlParameter prmlogin = new SqlParameter("@login", SqlDbType.VarChar, 255);
			prmlogin.Value = login;
			myCommand.Parameters.Add(prmlogin);

			SqlParameter prmname = new SqlParameter("@name", SqlDbType.VarChar, 255);
			prmname.Value = name;
			myCommand.Parameters.Add(prmname);

			SqlParameter prmadd1 = new SqlParameter("@add1", SqlDbType.VarChar, 255);
			prmadd1.Value = add1;
			myCommand.Parameters.Add(prmadd1);

			SqlParameter prmadd2 = new SqlParameter("@add2", SqlDbType.VarChar, 255);
			prmadd2.Value = add2;
			myCommand.Parameters.Add(prmadd2);

			SqlParameter prmcity = new SqlParameter("@city", SqlDbType.VarChar, 255);
			prmcity.Value = city;
			myCommand.Parameters.Add(prmcity);

			SqlParameter prmstate = new SqlParameter("@state", SqlDbType.VarChar, 255);
			prmstate.Value = state;
			myCommand.Parameters.Add(prmstate);

			SqlParameter prmzip = new SqlParameter("@zip", SqlDbType.VarChar, 10);
			prmzip.Value = zip;
			myCommand.Parameters.Add(prmzip);

			SqlParameter prmcountry = new SqlParameter("@country", SqlDbType.VarChar, 255);
			prmcountry.Value = country;
			myCommand.Parameters.Add(prmcountry);

			SqlParameter prmpwd = new SqlParameter("@pwd", SqlDbType.VarChar, 255);
			prmpwd.Value = password;
			myCommand.Parameters.Add(prmpwd);

			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				return "1";
			}
			catch (SqlException SQLexc)
			{
				return SQLexc.ToString();
			}
		}


		/// <summary>
		/// 处理用户登录事件
		/// </summary>
		/// <param name="strEmail">User email address</param>
		/// <param name="strPassword">User password</param>
		/// <returns>userDetails class if successful, or class containing Exception otherwise</returns>
		public UserDetails Login(string strEmail, string strPassword)
		{
			// Create Instance of Connection and Command Object
			SqlConnection  myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_login", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmEmail = new SqlParameter("@email", SqlDbType.VarChar, 255);
			prmEmail.Value = strEmail;
			myCommand.Parameters.Add(prmEmail);

			SqlParameter prmpwd = new SqlParameter("@pwd", SqlDbType.VarChar, 255);
			prmpwd.Value = strPassword;
			myCommand.Parameters.Add(prmpwd);

			SqlParameter prmlogin = new SqlParameter("@login", SqlDbType.VarChar, 255);
			prmlogin.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmlogin);

			SqlParameter prmuserID = new SqlParameter("@userID", SqlDbType.BigInt);
			prmuserID.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmuserID);

			UserDetails myuserDetails = new UserDetails();

			try
			{
				myConnection.Open();
				myCommand.ExecuteNonQuery();
				myConnection.Close();

				myuserDetails.login = prmlogin.Value.ToString();
				myuserDetails.user_id = Convert.ToInt32(prmuserID.Value);

				return myuserDetails;
			}
			catch (SqlException SQLexc)
			{
				myuserDetails.login = SQLexc.ToString();
				myuserDetails.user_id= 0;
				return myuserDetails;
			}
		}


		
		/// 查询某条竞标信息的竞标者信息
	
		public UserDetails GetuserByID(Int32 intuserID)
		{
			// Create Instance of Connection and Command Object
			SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			SqlCommand myCommand = new SqlCommand("sp_user_sel_by_id", myConnection);

			// Mark the Command as a SPROC
			myCommand.CommandType = CommandType.StoredProcedure;

			// Add Parameters to SPROC
			SqlParameter prmBidID = new SqlParameter("@bidid", SqlDbType.BigInt);
			prmBidID.Value = intuserID;
			myCommand.Parameters.Add(prmBidID);

			SqlParameter prmlogin = new SqlParameter("@login", SqlDbType.VarChar, 255);
			prmlogin.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmlogin);

			SqlParameter prmEmail = new SqlParameter("@email", SqlDbType.VarChar, 255);
			prmEmail.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmEmail);

			SqlParameter prmCity = new SqlParameter("@city", SqlDbType.VarChar, 255);
			prmCity.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmCity);

			SqlParameter prmState = new SqlParameter("@state", SqlDbType.VarChar, 255);
			prmState.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmState);

			SqlParameter prmCountry = new SqlParameter("@country", SqlDbType.VarChar, 255);
			prmCountry.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(prmCountry);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			// Create CustomerDetails Struct
			UserDetails myuserDetails = new UserDetails();
			myuserDetails.login = prmlogin.Value.ToString();
			myuserDetails.Email = prmEmail.Value.ToString();
			myuserDetails.City = prmCity.Value.ToString();
			myuserDetails.State = prmState.Value.ToString();
			myuserDetails.Country = prmCountry.Value.ToString();

			return myuserDetails;
		}
	}
}

