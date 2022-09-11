using Ardalis.HttpClientTestExtensions;
using Hospital.Web;
using PatientManagement.Core.CQRS.Patient.Responses;
using Xunit;

namespace Hospital.FunctionalTests.ControllerApis
{
    [Collection("Sequential")]
    public class PatientCreate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
    {
        private readonly HttpClient _client;

        public PatientCreate(CustomWebApplicationFactory<WebMarker> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsOnePatient()
        {
            var result = await _client.GetAndDeserializeAsync<IEnumerable<PatientResponse>>("/api/patient");

            Assert.NotEmpty(result);
            Assert.Contains(result, i => i.FullName == SeedData.TestProject1.Name);
        }
    }
}
