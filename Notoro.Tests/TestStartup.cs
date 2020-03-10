namespace Notoro.Tests
{
    using MyTested.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class TestStartup : Startup
    {

        public TestStartup(IConfiguration configuration) : base(configuration)
        {

        }
        
        public void ConfigureTestServices(IServiceCollection services)
        {


            base.ConfigureServices(services);



        }
    }
}