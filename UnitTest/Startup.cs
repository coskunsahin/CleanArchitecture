using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;
internal class Startup
{
    private IHostingEnvironment _host;

    public Startup(IHostingEnvironment host)
    {
        _host = host;
    }

    internal void ConfigureServices(ServiceCollection services)
    {
        throw new NotImplementedException();
    }
}