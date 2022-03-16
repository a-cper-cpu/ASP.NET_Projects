<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Security.Principal" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {   ///存储应用程序的状态    
		Application.Lock();
		Application["Data"] = "start";
		Application.UnLock();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
		///存储应用程序的状态    
		Application.Lock();
		Application["Data"] = "end";
		Application.UnLock();
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
		///存储应用程序的状态    
		Application.Lock();
		Application["Data"] = "error";
		Application.UnLock();
    }

    void Session_Start(object sender, EventArgs e) 
    {   ///表示用户登录成功
		Session["UserID"] = 1;
    }

    void Session_End(object sender, EventArgs e) 
    {   ///清楚对象
		Session["UserID"] = null;
		Session.Clear();
		///取消Session
		Session.Abandon();
	}	

	protected void Application_BeginRequest(object sender,EventArgs e)
	{   ///获取当前用户
		if(HttpContext.Current.User != null)
		{   ///当前用户是否被验证
			if(HttpContext.Current.User.Identity.IsAuthenticated == true)
			{   ///验证方式是否为窗体验证
				if(HttpContext.Current.User.Identity is FormsIdentity)
				{   ///创建验证的Ticket
					FormsIdentity formId = (FormsIdentity)HttpContext.Current.User.Identity;
					FormsAuthenticationTicket formTicket = formId.Ticket;
					///获取用户数据及其角色 
					string userData = formTicket.UserData;
					string[] roles = userData.Split(',');
					///创建新的验证
					HttpContext.Current.User = new GenericPrincipal(formId,roles);
				}
			}
		}
	}

	protected void Application_EndRequest(object sender,EventArgs e)
	{
		///验证结束时触发
	}
</script>
