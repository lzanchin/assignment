using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Net;

namespace ProductsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:49591/v1/products/3/right");
            request.Method = "GET";
            request.ContentType = "text/plain; charset=utf-8";
            var resp = request.GetResponse();
        }
    }
}
