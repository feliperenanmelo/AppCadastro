using AutoMapper;
using Confitec.Cadastro.Api.Extensoes;
using Confitec.Cadastro.IoC.Container;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Cadastro.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", true, true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfig(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.RegistrarInjecaoDependencia();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApiConfig(env);            
        }
    }
}
