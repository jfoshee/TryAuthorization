using System;

namespace TryAuthorization
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(Object sender, EventArgs e)
		{
			new AppHost().Init();
		}
	}
}
