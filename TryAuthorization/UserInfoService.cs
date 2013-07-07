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
	[Route("/userinfo")]
	[Route("/userinfo/{id}")]
	public class UserInfoRequest : IReturn<UserAuth>
	{
		public string Id { get; set; }
	}

	public class UserInfoService : Service
	{
		public UserAuth Get(UserInfoRequest request)
		{
			var session = this.GetSession();
			var id = request.Id ?? session.UserAuthId;
			var repo = TryResolve<IUserAuthRepository>();
			return repo.GetUserAuth(id);
		}
	}
}
