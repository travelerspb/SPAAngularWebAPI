using System;
using System.Security.Claims;
using System.Web;

namespace Jog.Common.Security
{
    public interface IUserSession
    {
        string Username { get; }
    }

    public interface IWebUserSession : IUserSession
    {
        Uri RequestUri { get; }
        string HttpRequestMethod { get; }
    }

    public class UserSession : IWebUserSession
    {
        public string Username
        {
            get
            {
                return ((ClaimsPrincipal) HttpContext.Current.User).FindFirst(ClaimTypes.Name).
                    Value;
            }
        }

        public Uri RequestUri
        {
            get { return HttpContext.Current.Request.Url; }
        }

        public string HttpRequestMethod
        {
            get { return HttpContext.Current.Request.HttpMethod; }
        }
    }
}