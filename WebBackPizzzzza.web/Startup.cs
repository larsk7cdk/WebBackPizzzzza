using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using WebBackPizzzzza.web.Filters;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.web
{
    public class Startup
    {
        private readonly List<CultureInfo> _supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("da-DK"),
            new CultureInfo("en-US")
        };

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IEmailService, EmailService>();


            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("da-DK");
                options.SupportedCultures = _supportedCultures;
                options.SupportedUICultures = _supportedCultures;
            });

            services.AddMvc(options =>
                    options.Filters.Add(typeof(UserRegistrationFilter))
                )
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.AddSession(o => { o.IdleTimeout = TimeSpan.FromMinutes(30); });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=UserRegistration}/{action=Index}/{id?}"
                );
            });
        }
    }
}