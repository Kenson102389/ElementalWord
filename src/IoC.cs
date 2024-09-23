using ElementalWords.Repository;
using ElementalWords.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementalWords
{
    public static class Ioc
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();
            AddServices(services);
            AddRepositories(services);
            return services.BuildServiceProvider();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IElementalWordsService, ElementalWordsService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddSingleton<IElementRepository, ElementRepository>();
        }
    }

}
