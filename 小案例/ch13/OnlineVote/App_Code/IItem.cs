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
/// 接口IItem
/// </summary>
public interface IItem
{
	/// <summary>
	/// 获取所有选择项信息
	/// </summary>
	/// <returns></returns>
	SqlDataReader GetItems();

	/// <summary>
	/// 获取投票主题的所有选择项
	/// </summary>
	/// <param name="nTopicID"></param>
	/// <returns></returns>
	SqlDataReader GetItemByTopic(int nTopicID);

	/// <summary>
	/// 获取投票项目的所有选择项
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	SqlDataReader GetItemBySubject(int nSubjectID);

	/// <summary>
	/// 获取投票项目的所有选择项的票的总数
	/// </summary>
	/// <param name="nSubjectID"></param>
	/// <returns></returns>
	SqlDataReader GetItemVoteCountBySubject(int nSubjectID);

	/// <summary>
	/// 获取单个选择项信息
	/// </summary>
	/// <param name="nItemID"></param>
	/// <returns></returns>
	SqlDataReader GetSingleItem(int nItemID);

	/// <summary>
	/// 添加新的选择项
	/// </summary>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int AddItem(string sName,int nSubjectID);

	/// <summary>
	/// 修改选择项信息
	/// </summary>
	/// <param name="nItemID"></param>
	/// <param name="sName"></param>
	/// <param name="sBody"></param>
	/// <returns></returns>
	int UpdateItem(int nItemID,string sName);

	/// <summary>
	/// 增加一票
	/// </summary>
	/// <param name="nItemID"></param>
	/// <returns></returns>
	int UpdateItemVoteCount(int nItemID);

	/// <summary>
	/// 删除选择项
	/// </summary>
	/// <param name="nItemID"></param>
	/// <returns></returns>
	int DeleteItem(int nItemID);
}