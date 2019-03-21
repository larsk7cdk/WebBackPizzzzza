using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Localization");

            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    options => options.ResourcesPath = "Localization").AddDataAnnotationsLocalization();


            services.AddSession(o => { o.IdleTimeout = TimeSpan.FromMinutes(30); });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseSession();

            // Localication Middlewares
            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("da-DK"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            localizationOptions.RequestCultureProviders.Clear();
            localizationOptions.RequestCultureProviders.Add(new CultureProviderResolverService());

            app.UseRequestLocalization(localizationOptions);
            // Localication Middlewares

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "areas",
                    "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}