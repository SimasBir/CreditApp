using CreditApp;
using CreditApp.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CreditAppIntegrationTest
{
    public class CreditAppIntegrationTest
    {
        private WebApplicationFactory<Program> _application;

        private HttpClient _client;

        public CreditAppIntegrationTest()
        {
            _application = new WebApplicationFactory<Program>();
            _client = _application.CreateClient();
        }

        [Fact]
        public async Task Test()
        {
            var credit = new Credit()
            {
                Amount = 50000,
                CurrentAmount = 0,
                Term = 12
            };

            var result = await _client.PostAsJsonAsync("/credit", credit);

            result.EnsureSuccessStatusCode();

            var creditDecision = await result.Content.ReadAsAsync<Answer>();

            creditDecision.Should().BeEquivalentTo(new Answer()
            {
                Approval = true,
                InterestRate = 0.05M
            });
        }
    }
}
