using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Function.IntegrationsTest
{
    [Collection(nameof(TestCollection))]
    public class WelcomeTest
    {
        private TestFixture testFixture;
        private HttpResponseMessage httpResponseMessage;

        public WelcomeTest(TestFixture fixture)
        {
            testFixture = fixture;
        }

        [Fact]
        public async Task WhenfunctioIsInvoked()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome?name=Shary");
            Assert.True(httpResponseMessage.IsSuccessStatusCode);
        }
        /*
        [Fact]
        public async Task WhenResponseWndWith()
        {
            httpResponseMessage = await testFixture.Client.GetAsync("api/Welcome?name=Shary");
            Assert.EndsWith("success.", await httpResponseMessage.Content.ReadAsStringAsync());
        }*/
    }
}
