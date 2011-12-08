using System.Net;
using System.Web;

namespace TeliaCore.Infrastructure
{
	public interface ISessionValidator
	{
		SessionToken ValidateSession();
	}
	public class SessionValidator : ISessionValidator
	{
		private readonly HttpContextBase httpContextBase;

		public SessionValidator(HttpContextBase httpContextBase)
		{
			this.httpContextBase = httpContextBase;
		}

		public SessionToken ValidateSession()
		{
			//TODO validation
			var sessionToken = new SessionToken
			{
				IpAddress = IPAddress.Parse(httpContextBase.Request.UserHostAddress),
				IsValid = true
			};

			return sessionToken;
		}
	}
}
