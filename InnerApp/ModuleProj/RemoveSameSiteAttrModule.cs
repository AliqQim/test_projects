using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ModuleProj
{
    public class RemoveSameSiteAttrModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += Context_PreSendRequestHeaders;
        }

        private void Context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            ModifyCookieHeaders(HttpContext.Current.Response.Headers);

        }

        public void ModifyCookieHeaders(NameValueCollection headers)
        {
            headers.Remove("non-existant bitch");  //несуществующий не ~исключенится
            string cookieStr = headers["Set-Cookie"];

            headers.Remove("Set-Cookie");


            
            
            string cookieStrToSet = ProcessCookieString(cookieStr);

            headers.Add("Set-Cookie", cookieStrToSet);
        }


        Regex _sameSiteRegex = new Regex(@"SameSite\s*\=\s*(Lax|Strict)\s*\;?", RegexOptions.Compiled);
        Regex _semicolonRegex = new Regex(@"\;\s*\,", RegexOptions.Compiled);
        private string ProcessCookieString(string cookieStr)
        {
            if (cookieStr == null)
                return null;
            string res = _sameSiteRegex.Replace(cookieStr, "");
            res = _semicolonRegex.Replace(res, ",");

            return res;
        }
    }
}