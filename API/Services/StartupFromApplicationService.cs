using System;
using API.Data;
using API.Helpers;
using API.Profiles;
using API.Repository;
using API.Repository.IRepository;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Services
{
    public static class StartupFromApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<LogUserActivity>();

            services.AddScoped<IKPErpCrmDesignRecordRepository, KPErpCrmDesignRecordRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            //services.AddAutoMapper(typeof(ProductsProfiles).Assembly);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  //��profiles�ļ�����ɨ��profile�ļ�(profiles�ļ��б�����)��ȡ������һ�䣿


            return services;
        }
    }
}