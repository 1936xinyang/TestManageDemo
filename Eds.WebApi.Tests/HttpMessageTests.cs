using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Eds.WebApi.Tests
{
    public class HttpMessageTests
    {
        [Fact]
        public void HttpRequestMessage_is_easy_to_instantiate()
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                new Uri("http://www.ietf.org/rfc/rfc2616.txt"));
            Assert.Equal(HttpMethod.Get,request.Method);
            Assert.Equal("http://www.ietf.org/rfc/rfc2616.txt", request.RequestUri.ToString());
            Assert.Equal(new Version(1,1), request.Version);
        }
        [Fact]
        public void HttpResponseMessage_is_easy_to_instantiate()
        {
            var response = new HttpResponseMessage(
                HttpStatusCode.OK);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(new Version(1, 1), response.Version);
        }
        [Fact]
        public async Task New_HTTP_methods_can_be_used()
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"),
                new Uri("http://www.ietf.org/rfc/rfc2616.txt"));
            using (var client=new HttpClient())
            {
                var resp = await client.SendAsync(request);
                Assert.Equal(System.Net.HttpStatusCode.MethodNotAllowed,resp.StatusCode);
            }

        }

        [Fact]
        public  void New_status_codes_can_also_be_used()
        {
            var response = new HttpResponseMessage(
                (HttpStatusCode)418)
            {
                ReasonPhrase = "I'm a teapot"
            };
            Assert.Equal((int)response.StatusCode, 418);

        }

    }
}
