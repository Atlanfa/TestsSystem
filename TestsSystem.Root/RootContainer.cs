using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TestsSystem.Business.Contracts;
using TestsSystem.Business.Services;
using TestsSystem.SqlData;
using TestsSystem.SqlData.Contracts;
using TestsSystem.SqlData.Repositories;

namespace TestsSystem.Root
{
    public static class RootContainer
    {
        public static void InjectRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestsSystemContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("TsConnection"));
            });
            services.AddTransient<IRepoRootUsers, RepoRootUsers>();
            services.AddTransient<IRepoStudents, RepoStudents>();
            services.AddTransient<IRepoPrepods, RepoPrepods>();
            services.AddTransient<IRepoSubjects, RepoSubjects>();
            services.AddTransient<IRepoThemes, RepoThemes>();
            services.AddTransient<IRepoQuestions, RepoQuestions>();
            services.AddTransient<IRepoAnswers, RepoAnswers>();
        }

        public static void InjectBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Business.MappingProfile));
            services.AddTransient<IServAppUsers, ServAppUsers>();
            services.AddTransient<IServSubjects, ServSubjects>();
            services.AddTransient<IServThemes, ServThemes>();
            services.AddTransient<IServQuestions, ServQuestions>();
            services.AddTransient<IServAnswers, ServAnswers>();
        }
    }
}