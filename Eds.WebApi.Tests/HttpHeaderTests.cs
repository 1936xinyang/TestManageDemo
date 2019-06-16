using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace Eds.WebApi.Tests
{
    public class HttpHeaderTests
    {
        /// <summary>
        /// Message_and_content_headers_are_not_in_same_coll
        /// 请求和响应消息类都包含一个Headers属性，内容标头属于内容标头集合，可通过HttpContent的Headers属性访问
        /// </summary>
        [Fact]
        public async Task Headerscoll()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://www.baidu.com");
                var request = response.RequestMessage;
                //Assert.AreEqual("www.baidu.com", request.Headers.Host);
                Assert.NotNull(response.Headers.Server);
                Assert.Equal("text/html", response.Content.Headers.ContentType.MediaType);
            }
        }
        [Fact]
        public void Classes_expose_headers_in_a_strongly_typed_way()
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Accept",
                "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            HttpHeaderValueCollection<System.Net.Http.Headers.MediaTypeWithQualityHeaderValue> accept = request.Headers.Accept;
            Assert.Equal(4, accept.Count);
            MediaTypeWithQualityHeaderValue third = accept.Skip(2).First();
            Assert.Equal(0.9, third.Quality);
            Assert.Null(third.CharSet);
            Assert.Equal(1, third.Parameters.Count);
            Assert.Equal("q", third.Parameters.First().Name);
            Assert.Equal("0.9", third.Parameters.First().Value);

        }
        [Fact]

        public void Properties_simplify_header_construction()
        {
            var response = new HttpResponseMessage();
            //不使用字符串，简化了构建正确的标头值的过程
            response.Headers.Date = new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.FromHours(0));
            response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromMinutes(1),
                Private = true
            };
            var dateValue = response.Headers.First(h => h.Key == "Date").Value.First();
            Assert.Equal("Tue, 01 Jan 2019 00:00:00 GMT", dateValue);
            var cacheControlValue = response.Headers.First(h => h.Key == "Cache-Control").Value.First();
            Assert.Equal("max-age=60, private", cacheControlValue);
        }
        [Fact]
        public void Add_validates_value_domain_for_std_headers()
        {
            var request = new HttpResponseMessage();
            Assert.Throws<FormatException>(() => request.Headers.Add("Date", "invalid-date"));
            request.Headers.Add("Strict-Transport-Security", "invalid;;value");
        }
        [Fact]
        public void TryAddWithoutValidation_doesnt_validates_the_value_but_preserves_it()
        {
            var request = new HttpRequestMessage();
            Assert.True(request.Headers.TryAddWithoutValidation("Date", "invalid-date"));
            Assert.Equal(null, request.Headers.Date);
            Assert.Equal("invalid-date", request.Headers.GetValues("Date").First());

            //var content = new HttpMessageContent(request);
            //var s = await content.ReadAsStringAsync();
            //Assert.IsTrue(s.Contains("Date: invalid-date"));
        }
    }
}
