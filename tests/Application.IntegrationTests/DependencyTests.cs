using System.Text;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ArchitectureSolutions.Application.IntegrationTests;
public class DependencyTests
{
    [Test]
    public void RegistrationValidation()
    {
        var app = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            builder.ConfigureTestServices(serviceCollection =>
            {
                var services = serviceCollection.ToList();
                var result = ValidateServices(services);
                if (!result.Success)
                {
                    Assert.Fail(result.Message);
                }
                Assert.Pass();
            }));
    }
    private class DependencyAssertionResult
    {
        public bool Success { get; init; }
        public string Message { get; init; }
    }
    private DependencyAssertionResult ValidateServices(List<ServiceDescriptor> services)
    {
        var searchFailed = false;
        var failedText = new StringBuilder();
        //foreach(var descriptor in _descriptors)
        //{
        //    var match = services.SingleOrDefault(
        //        )
        //}
        return new DependencyAssertionResult() { Success = true };
    }
}



