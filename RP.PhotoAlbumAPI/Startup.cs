using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;
using RP.PhotoAlbum.Provider.Feature.Repository;
using RP.PhotoAlbum.Provider.Feature.Repository.Interface;
using RP.PhotoAlbum.Provider.Feature.Service;
using RP.PhotoAlbum.Provider.Feature.Service.Interface;

namespace RP.PhotoAlbumAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRestClient>(new RestClient(Configuration.GetSection("DataSource")["API"]));

            services.AddSingleton<IAlbumRepository, AlbumRepository>();
            services.AddSingleton<IPhotoRepository, PhotoRepository>();
            services.AddSingleton<IPhotoAlbumService, PhotoAlbumService>();

            services.AddControllers();
        }

        // Leaving default configurations, although not necessary for the spec
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
