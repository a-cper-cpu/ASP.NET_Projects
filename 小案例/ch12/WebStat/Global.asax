<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {	///初始化Application统计信息
		if(Application["Visitor"] == null)
		{   ///初始化
			Application.Lock();
			Application["Visitor"] = 1;
			Application.UnLock();
		}		
    }
    
    void Application_End(object sender, EventArgs e) 
    {	
		///
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
	{	///使用Application统计
		if(Application["Visitor"] == null)
		{   ///初始化
			Application.Lock();
			Application["Visitor"] = 1;
			Application.UnLock();
		}
		else
		{   ///计数器加一
			Application.Lock();
			Application["Visitor"] = Int32.Parse(Application["Visitor"].ToString()) + 1;
			Application.UnLock();
		}
    }

    void Session_End(object sender, EventArgs e)
	{   ///使用Application统计
		if(Application["Visitor"] != null)
		{   ///计数器减一
			Application.Lock();
			Application["Visitor"] = Int32.Parse(Application["Visitor"].ToString()) - 1;
			Application.UnLock();
		}      
    }
       
</script>
