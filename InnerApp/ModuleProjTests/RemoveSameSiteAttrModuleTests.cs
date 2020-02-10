using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleProj;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ModuleProj.Tests
{
    [TestClass()]
    public class SameSiteAttrModuleTests
    {
        static private string _cookieKey = "Set-Cookie";


        RemoveSameSiteAttrModule CreateTarget()
        {
            return new RemoveSameSiteAttrModule();
        }



        [TestMethod()]
        public void ModifyCookieHeaders_одинLaxВКонце_удаляется()
        {
            var input = new NameValueCollection();

            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly; SameSite=Lax");

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            string res = input[_cookieKey];

            var expectedRes = "InnerApp_SessionId=5645; path=/; HttpOnly; ";
            Assert.AreEqual(res, expectedRes);
        }

        [TestMethod()]
        public void ModifyCookieHeaders_Strict_удаляется()
        {
            var input = new NameValueCollection();

            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly; SameSite=Strict");

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            string res = input[_cookieKey];

            var expectedRes = "InnerApp_SessionId=5645; path=/; HttpOnly; ";
            Assert.AreEqual(res, expectedRes);
        }

        [TestMethod()]
        public void ModifyCookieHeaders_LaxВКонцеТочкаЗапятая_удаляется()
        {
            var input = new NameValueCollection();

            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly; SameSite=Lax;");

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            string res = input[_cookieKey];

            var expectedRes = "InnerApp_SessionId=5645; path=/; HttpOnly; ";
            Assert.AreEqual(res, expectedRes);
        }

        [TestMethod()]
        public void ModifyCookieHeaders_ПробелыИмеются_удаляется()
        {
            var input = new NameValueCollection();

            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly;SameSite = Lax ;");

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            string res = input[_cookieKey];

            var expectedRes = "InnerApp_SessionId=5645; path=/; HttpOnly;";
            Assert.AreEqual(res, expectedRes);
        }

        [TestMethod()]
        public void ModifyCookieHeaders_НесколькоКукиSameSiteВСередине_удаляется()
        {
            var input = new NameValueCollection();

            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly; SameSite=Lax,cookieVal=27; path=/; HttpOnly;");

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            string res = input[_cookieKey];

            var expectedRes = "InnerApp_SessionId=5645; path=/; HttpOnly,cookieVal=27; path=/; HttpOnly;";
            Assert.AreEqual(res, expectedRes);
        }

        [TestMethod()]
        public void ModifyCookieHeaders_НесколькоКукиSameSiteВСерединеСТОчкойЗапятой_удаляется()
        {
            var input = new NameValueCollection();

            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly; SameSite=Lax; ,cookieVal=27; path=/; HttpOnly;");

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            string res = input[_cookieKey];

            var expectedRes = "InnerApp_SessionId=5645; path=/; HttpOnly,cookieVal=27; path=/; HttpOnly;";
            Assert.AreEqual(res, expectedRes);
        }

        [TestMethod()]
        public void ModifyCookieHeaders_НесколькоВхождений_УдаляютсяВсе()
        {
            var input = new NameValueCollection();

            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly; SameSite=Lax; ,cookieVal=27; path=/; HttpOnly;");
            input.Add(_cookieKey,
                "InnerApp_SessionId=5645; path=/; HttpOnly; SameSite=Lax; ,cookieVal=27; path=/; HttpOnly;");

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            string res = input[_cookieKey];

            var expectedRes = "InnerApp_SessionId=5645; path=/; HttpOnly,cookieVal=27; path=/; HttpOnly,InnerApp_SessionId=5645; path=/; HttpOnly,cookieVal=27; path=/; HttpOnly;";
            Assert.AreEqual(res, expectedRes);
        }

        [TestMethod()]
        public void ModifyCookieHeaders_НетВхождения_НеПадает()
        {
            var input = new NameValueCollection();


            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            //нет исключения

        }

        [TestMethod()]
        public void ModifyCookieHeaders_Null_НеПадает()
        {
            var input = new NameValueCollection();
            input.Add(_cookieKey, null);

            var target = CreateTarget();


            target.ModifyCookieHeaders(input);

            //нет исключения

        }


    }
}
