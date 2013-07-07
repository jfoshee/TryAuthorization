using System;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.ServiceInterface.Admin;
using System.Collections.Generic;

namespace TryAuthorization
{
	public class AppHost : AppHostBase 
	{
		public AppHost() : base("TryAuthorization", System.Reflection.Assembly.GetExecutingAssembly())
		{
		}

		public override void Configure(Funq.Container container)
		{
			Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[] {
				new BasicAuthProvider(),
				new CredentialsAuthProvider(),
			}));
			Plugins.Add(new RegistrationFeature());

			container.Register<ICacheClient>(new MemoryCacheClient { FlushOnDispose = false });
			var userRep = new InMemoryAuthRepository();
			userRep.CreateUserAuth(
				new UserAuth { 
					UserName = "admin", 
					Roles = new List<string> { "Admin" },
				},
				"deathstar");
			container.Register<IUserAuthRepository>(userRep);
		}
	}
}
