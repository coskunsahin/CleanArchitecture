using System.Diagnostics;

namespace TestProject1;

internal record Invoice(int? Id, string? Name, string?  people, string? worker, string? categories, double? quantity, double? price);
public class InvoiceTest : IDisposable
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://localhost:5001/api")
    };

    public void Dispose()
    {
        _httpClient.DeleteAsync("/").GetAwaiter().GetResult();
    }

    [Fact]
    public async Task GivenARequest_WhenCallingGetInvoice_ThenTheAPIReturnsExpectedResponse()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.OK;
        var expectedContent = new[]
        {
            new Invoice(1, "COSKUN","yes","no","grocies",744445,10),
           new Invoice(1, "COSKUN","yes","no","grocies",744445,10),
           new Invoice(1, "COSKUN","yes","no","grocies",744445,10),
           new Invoice(1, "COSKUN","yes","no","grocies",744445,10),
                              

        };
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.GetAsync("/invoice");

        // Assert.
        await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
    }

    [Fact]
    public async Task GivenARequest_WhenCallingPostInvoice_ThenTheAPIReturnsExpectedResponseAndAddsBook()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.Created;
        var expectedContent = new  Invoice(6, "COSKUN", "yes", "no", "grocies", 744445, 10);
        var stopwatch = Stopwatch.StartNew();

        // Act.
        var response = await _httpClient.PostAsync("/invoice", TestHelpers.GetJsonStringContent(expectedContent));

        // Assert.
        await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
    }

 

   

    [Fact]
    public async Task GivenAnAuthenticatedRequest_WhenCallingAdmin_ThenTheAPIReturnsExpectedResponse()
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.OK;
        var expectedContent = "Hi admin!";
        var stopwatch = Stopwatch.StartNew();
        var request = new HttpRequestMessage(HttpMethod.Get, "/admin");
        request.Headers.Add("X-Api-Key", "SuperSecretApiKey");

        // Act.
        var response = await _httpClient.SendAsync(request);

        // Assert.
        await TestHelpers.AssertResponseWithContentAsync(stopwatch, response, expectedStatusCode, expectedContent);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("WrongApiKey")]
    public async Task GivenAnUnauthenticatedRequest_WhenCallingAdmin_ThenTheAPIReturnsUnauthorized(string? apiKey)
    {
        // Arrange.
        var expectedStatusCode = System.Net.HttpStatusCode.Unauthorized;
        var stopwatch = Stopwatch.StartNew();
        var request = new HttpRequestMessage(HttpMethod.Get, "/admin");
        request.Headers.Add("X-Api-Key", apiKey);

        // Act.
        var response = await _httpClient.SendAsync(request);

        // Assert.
        TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
    }
}


