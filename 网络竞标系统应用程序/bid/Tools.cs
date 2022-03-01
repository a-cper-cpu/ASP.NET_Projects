using System;
using System.Web;

namespace Bid
{
	public class Tools
	{
		public static bool IsLoggedIn()
		{
			HttpContext ctx = HttpContext.Current;
			
			if (ctx.Request.Cookies["email"] == null ||
				ctx.Request.Cookies["email"].Value == "")
				return false;
			else
				return true;
		}
	}
}

