using StarWars.Application;
using StarWars.Domain.Handlers;
using StarWars.Domain.Interfaces;
using StarWars.Infra.CrossCutting.Logging;
using StarWars.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace StarWars.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        #region Public Methods

        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            #region Applications

            services.AddScoped<ILocalizacaoApplication, LocalizacaoApplication>();
            services.AddScoped<IRebeldeApplication, RebeldeApplication>();
            services.AddScoped<IItemApplication, ItemApplication>();

            #endregion

            #region Repositories

            services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
            services.AddScoped<IRebeldeRepository, RebeldeRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            #endregion

            #region Others

            services.AddScoped<ILogger, NLogLogger>();
            services.AddScoped<INotificator, NotificatorHandler>();

            #endregion

            return services;
        }

        #endregion
    }
}