using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.IO;

public partial class Sender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void NewBtn_Click(object sender,EventArgs e)
	{
		int nContain = 0;

		///添加发件人地址
		string from = "zhengyd@gucas.ac.cn";
		MailMessage mailMsg = new MailMessage();
		mailMsg.From = new MailAddress(from);
		nContain += mailMsg.From.Address.Length;

		///添加收件人地址
		string split = ";";
		string[] toList = To.Text.Trim().Split(split.ToCharArray());
		for(int i = 0; i < toList.Length; i++)
		{
			mailMsg.To.Add(toList[i].Trim());
		}
		nContain += To.Text.Length;

		///添加抄送地址；
		string[] ccList = CC.Text.Trim().Split(split.ToCharArray());
		for(int i = 0; i < ccList.Length; i++)
		{
			if(ccList[i].Trim().Length > 0)
			{
				mailMsg.CC.Add(ccList[i].Trim());
			}
		}
		nContain += CC.Text.Length;

		///添加邮件主题
		mailMsg.Subject = Title.Text.Trim();
		mailMsg.SubjectEncoding = Encoding.UTF8;
		nContain += mailMsg.Subject.Length;

		///添加邮件内容
		mailMsg.Body = Body.Text;
		mailMsg.BodyEncoding = Encoding.UTF8;
		mailMsg.IsBodyHtml = HtmlCB.Checked;
		nContain += mailMsg.Body.Length;

		///添加邮件附件		
		HttpFileCollection fileList = HttpContext.Current.Request.Files;
		for(int i = 0; i < fileList.Count; i++)
		{   ///添加单个附件
			HttpPostedFile file = fileList[i];
			if(file.FileName.Length <= 0 || file.ContentLength <= 0)
			{
				break;
			}
			Attachment attachment = new Attachment(file.FileName);			
			mailMsg.Attachments.Add(attachment);
			nContain += file.ContentLength;
		}

		if(mailMsg.IsBodyHtml == true)
		{
			nContain += 100;
		}

		try
		{   ///发送邮件
			IMail mail = new Mail();
			mail.SenderMail(mailMsg);

			///保存发送的邮件
			int nMailID = mail.SaveAsMail(mailMsg.Subject,mailMsg.Body,from,
				To.Text.Trim(),CC.Text.Trim(),mailMsg.IsBodyHtml,
				nContain,mailMsg.Attachments.Count > 0 ? true : false);
			
			if(nMailID > 0)
			{   ///保存发送邮件的附件
				for(int i = 0; i < fileList.Count; i++)
				{   ///添加单个附件
					HttpPostedFile file = fileList[i];
					if(file.FileName.Length <= 0 || file.ContentLength <= 0)
					{
						break;
					}
					///保存附件到硬盘中
					file.SaveAs(MapPath("MailAttachments/" + Path.GetFileName(file.FileName)));
					///保存发送邮件的附件
					mail.SaveAsMailAttachment(
						Path.GetFileName(file.FileName),
						"MailAttachments/" + Path.GetFileName(file.FileName),
						file.ContentType,
						file.ContentLength,
						nMailID);
				}
			}			
		}
		catch(Exception ex)
		{   ///跳转到异常错误处理页面
			Response.Redirect("ErrorPage.aspx?ErrorMsg=" + ex.Message.Replace("<br>","").Replace("\n","")
				+ "&ErrorUrl=" + Request.Url.ToString().Replace("<br>","").Replace("\n",""));
		}
		Response.Redirect("~/MailDesktop.aspx");
	}
	protected void ReturnBtn_Click(object sender,EventArgs e)
	{   ///返回到邮件列表页面
		Response.Redirect("~/MailDesktop.aspx");
	}	
}
