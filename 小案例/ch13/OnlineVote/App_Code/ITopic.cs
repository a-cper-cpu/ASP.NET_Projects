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
/// 接口ITopic
/// </summary>
public interface ITopic
{
	/// <summary>
	/// 获取所有投票主题信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetTopics();

	/// <summary>
	/// 获取当前投票主题
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetCurrentTopic();

	/// <summary>
	/// 获取单个投票主题信息
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleTopic(int nTopicID);

	/// <summary>
	/// 添加新的投票主题
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int AddTopic(string sName,string sBody);

	/// <summary>
	/// 修改投票主题信息
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int UpdateTopic(int nTopicID,string sName,string sBody);

	/// <summary>
	/// 设置投票主题为当前投票主题
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	int UpdateTopicCurrent(int nTopicID);

	/// <summary>
	/// 删除投票主题
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	int DeleteTopic(int nTopicID);
}
