using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// 接口ISubject
/// </summary>
public interface ISubject
{
	/// <summary>
	/// 获取所有投票项目信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetSubjects();

	/// <summary>
	/// 获取投票项目的所有投票主题
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	SqlDataReader GetSubjectByTopic(int nTopicID);

	/// <summary>
	/// 获取单个投票项目信息
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleSubject(int nSubjectID);

	/// <summary>
	/// 添加新的投票项目
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int AddSubject(string sName,int nMode,int nTopicID);

	/// <summary>
	/// 修改投票项目
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int UpdateSubject(int nSubjectID,string sName,int nMode);	

	/// <summary>
	/// 删除投票项目
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	int DeleteSubject(int nSubjectID);
}
