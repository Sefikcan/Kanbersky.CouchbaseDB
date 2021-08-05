using Couchbase.Extensions.DependencyInjection;
using Kanbersky.CouchbaseDB.Abstract;
using Kanbersky.CouchbaseDB.Concrete;
using Kanbersky.CouchbaseDB.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kanbersky.CouchbaseDB.Extensions
{
    public static class RegisterCouchbaseDbExtensions
    {
        public static IServiceCollection RegisterKanberskyCouchbaseDB(this IServiceCollection services, IConfiguration configuration)
        {
            CouchbaseDBSettings couchbaseDBSettings = new CouchbaseDBSettings();
            configuration.GetSection(nameof(CouchbaseDBSettings)).Bind(couchbaseDBSettings);
            services.AddSingleton(couchbaseDBSettings);

            services.AddCouchbase(configuration.GetSection(nameof(CouchbaseDBSettings)));
            services.AddScoped(typeof(ICouchbaseRepository<>), typeof(CouchbaseRepository<>));
            return services;
        }

        public static IApplicationBuilder UseKanberskyCouchbaseDB(this IApplicationBuilder app, IHostApplicationLifetime host)
        {
            host.ApplicationStopped.Register(() =>
            {
                app.ApplicationServices
                   .GetRequiredService<ICouchbaseLifetimeService>().Close();
            });

            return app;
        }
    }
}
