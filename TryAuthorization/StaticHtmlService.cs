using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;

namespace TryAuthorization
{
	[Route("/html/{name}")]
	public class StaticHtmlRequest
	{
		public string Name { get; set; }
	}

	public class StaticHtmlService : Service
	{
		public object Get(StaticHtmlRequest request)
		{
			return new HttpResult(new FileInfo(request.Name + ".html"), false);
		}
	}
}
