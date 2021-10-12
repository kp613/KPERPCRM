using System.Text;
using API.Data;
using API.Models.IdentityModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public static class StartupFromIdentityService
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<ApplicationRole>()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddRoleValidator<RoleValidator<ApplicationRole>>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(config["Authentication:SecretKey"])),

                        ValidIssuer = config["Authentication:Issuer"],
                        ValidateIssuer = false,      //选择true，则usercontroller中列表出错

                        ValidateAudience = false,       //重要：Microsoft的缺省设置取消，以免影响本次设置而出错
                        //ValidAudience = config["Authentication:Audience"],
                        ValidateLifetime = true,    //20211003
                    };

                });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
                opt.AddPolicy("IsAdmin", policy => policy.RequireClaim("age", "19"));   //使用claim设置董事会成员等
                opt.AddPolicy("IsAdmin", policy => policy.RequireClaim("age", "19").RequireRole("Admin"));  //使用组合,roles设置CRUD或特殊的area，claim设置部门和角色？
            });

            return services;
        }
    }
}