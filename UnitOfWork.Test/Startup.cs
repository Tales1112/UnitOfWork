using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unity_Of_Work;
using Unity_Of_Work.Repositories.Interfaces;
using Unity_Of_Work.Repositories.Repositories;

namespace UnitOfWork.Test
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUnitOfWork, UnityOfWork>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
