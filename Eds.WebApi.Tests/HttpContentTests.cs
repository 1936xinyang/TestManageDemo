using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Xunit;

namespace Eds.WebApi.Tests
{
    public class HttpContentTests
    {
        [Fact]
        public async Task HttpContent_can_be_consumed_in_push_style()
        {
            using (var clinet=new HttpClient())
            {
                var response = await clinet.GetAsync("http://www.baidu.com",HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var ms = new MemoryStream();
                await response.Content.CopyToAsync(ms);
                Assert.True(ms.Length>0);
            }
        }
        [Fact]
        public async Task HttpContent_can_be_consumed_using_formatters()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://api.github.com/users/webapibook");
                response.EnsureSuccessStatusCode();
                var user = await response.Content.ReadAsAsync<GitHubUser>(new MediaTypeFormatter[] {
                    new JsonMediaTypeFormatter()
                });
                Assert.Equal("webapibook",user.Login);
                Assert.Equal("Organization", user.Type);

            }
        }
    }

    internal class GitHubUser
    {
        public string Login { get; set; }
        public string Type { get; set; }

    }
}
