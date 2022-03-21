using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
	private static string sValidator = "";
	private StringBuilder LetterList = new StringBuilder();
	private readonly string sValidatorImageUrl = "ValidateImage.aspx?Validator=";

	protected void Page_Load(object sender,EventArgs e)
	{
		///添加页面初始化代码
		if(!Page.IsPostBack)
		{
			///创建验证字符串
			sValidator = CreateValidateString(6);
			ValidateImage.ImageUrl = sValidatorImageUrl + sValidator;
		}
	}

	protected void LoginBtn_Click(object sender,EventArgs e)
	{
		///如果页面输入合法
		if(Page.IsValid == true)
		{
			if(Validator.Text != sValidator)
			{
				Message.Text = "验证码输入错误，请重新输入验证码！！！";
				sValidator = CreateValidateString(6);
				ValidateImage.ImageUrl = sValidatorImageUrl + sValidator;
				return;
			}

			String userId = "";

			///定义类并获取用户的登陆信息            
			IUser user = new User();

			///对用户输入进行编码
			string sUserName = Server.HtmlEncode(UserName.Text.Trim());
			string sPassword = Server.HtmlEncode(Password.Text.Trim());
			
			///获取用户信息
			SqlDataReader recu = user.GetUserLoginByProc(sUserName,
				user.Encrypt(sPassword));

			///判断用户是否合法
			if(recu.Read())
			{
				userId = recu["UserID"].ToString();
			}
			recu.Close();

			///验证用户合法性，并跳转到系统平台
			if((userId != null) && (userId != ""))
			{
				Session["UserID"] = userId;

				//跳转到登录后的第一个页面
				Response.Redirect("~/UserManage.aspx");
			}
			else
			{
				///创建验证字符串
				sValidator = CreateValidateString(6);
				ValidateImage.ImageUrl = sValidatorImageUrl + sValidator;
				///显示错误信息
				Message.Text = "你输入的用户名称或者密码有误，请重新输入！";
			}
		}
	}

	protected void CancelBtn_Click(object sender,EventArgs e)
	{
		///清空用户名称和密码输入框
		UserName.Text = Password.Text = "";

		///创建验证字符串
		sValidator = CreateValidateString(6);
		ValidateImage.ImageUrl = sValidatorImageUrl + sValidator;
	}

	/// <summary>
	/// 创建一个随机数
	/// </summary>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	private int GetRandomint(int min,int max)
	{
		Random random = new Random();
		return (random.Next(min,max));
	}

	/// <summary>
	/// 创建验证字符串
	/// </summary>
	/// <param name="nLen"></param>
	/// <returns></returns>
	private string CreateValidateString(int nLen)
	{
		///初始化
		InitLetterList();

		///创建一个StringBuilder对象
		StringBuilder sb = new StringBuilder(nLen);
		for(int i = 0; i < nLen; i++)
		{
			int index = GetRandomint(0,LetterList.Length - 1);
			sb.Append(LetterList[index].ToString());
			LetterList.Remove(index,1);
		}
		return (sb.ToString());
	}

	/// <summary>
	/// 创建所有字符，为创建验证字符串做准备
	/// </summary>
	private void InitLetterList()
	{
		for(int i = 0; i < 10; i++)
		{
			LetterList.Append(i.ToString());
		}
		for(int i = 0; i < 26; i++)
		{
			LetterList.Append(((char)((int)'a' + i)).ToString());
		}
		for(int i = 0; i < 26; i++)
		{
			LetterList.Append(((char)((int)'A' + i)).ToString());
		}
	}
}
