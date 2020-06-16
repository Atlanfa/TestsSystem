using AutoMapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

using TestsSystem.Core.Security;
using TestsSystem.Web.AutoMapper;
using TestsSystem.Web.Contracts;
using TestsSystem.Web.Models.VO;
using TestsSystem.Web.Services.Business;

namespace TestsSystem.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddViewBusiness(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".TestsSystemView.Session";
            });
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddTransient<IServSession, ServSession>();
            services.AddTransient<IServHttpApi, ServHttpApi>();
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<IServPrepods, ServPrepods>();
            services.AddTransient<IServStudents, ServStudents>();
            services.AddTransient<IServItems, ServItems>();

        }

        public static void AddApiData(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiCredentials>(configuration
                .GetSection("ApiCredentials"));
            services.Configure<WebViewSettings>(configuration
                .GetSection("WebViewSettings"));
            services.AddHttpClient<HttpContext>(configure =>
            {
                configure.BaseAddress = new Uri(configuration.GetApiEndpoint());
            }).SetHandlerLifetime(TimeSpan.FromMinutes(3));
            services.AddTransient<IServHttpApi, ServHttpApi>();
        }

        public static void ConfigureViewLocationFormats(this IMvcBuilder builder)
        {

        }
    }
}
