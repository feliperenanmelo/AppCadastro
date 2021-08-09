using Confitec.Cadastro.Data.Context;
using Confitec.Cadastro.Data.Repository;
using Confitec.Cadastro.Models.Interfaces;
using Confitec.Cadastro.Models.Notificacoes;
using Confitec.Cadastro.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Cadastro.IoC.Container
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection RegistrarInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<ConfitecDbContext>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
