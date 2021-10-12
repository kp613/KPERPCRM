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
                        ValidateIssuer = false,      //ѡ��true����usercontroller���б����

                        ValidateAudience = false,       //��Ҫ��Microsoft��ȱʡ����ȡ��������Ӱ�챾�����ö�����
                        //ValidAudience = config["Authentication:Audience"],
                        ValidateLifetime = true,    //20211003
                    };

                });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
                opt.AddPolicy("IsAdmin", policy => policy.RequireClaim("age", "19"));   //ʹ��claim���ö��»��Ա��
                opt.AddPolicy("IsAdmin", policy => policy.RequireClaim("age", "19").RequireRole("Admin"));  //ʹ�����,roles����CRUD�������area��claim���ò��źͽ�ɫ��
            });

            return services;
        }
    }
}