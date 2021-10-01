using API.Data;
using API.Data.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using API.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServices(_config);
            services.AddApplicationServices(_config);

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddControllers();

            //services.AddSingleton<IConnectionMultiplexer>(c =>
            //{
            //    var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
            //    return ConnectionMultiplexer.Connect(configuration);
            //});

            services.AddControllers().AddNewtonsoftJson(option =>
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddRoles<IdentityRole>()       //如果使用services.AddIdentity<IdentityUser，IdentityRole>，则_ManageNav不能使用
            //    .AddDefaultTokenProviders()
            //    //.AddDefaultUI()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddCors();
            services.AddMvc();


            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();

            if (_env.IsDevelopment())
            {

                services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                _config.GetConnectionString("IdentityDefaultConnection_env"), providerOptions => providerOptions.EnableRetryOnFailure()));

                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                _config.GetConnectionString("DefaultConnection_env"), providerOptions => providerOptions.EnableRetryOnFailure()));

                services.AddDbContext<WebDbContext>(options =>
                options.UseSqlServer(
                    _config.GetConnectionString("WebDefaultConnection_env"), providerOptions => providerOptions.EnableRetryOnFailure()));

                //services.AddDbContext<ApplicationDbContext>(x =>
                //x.UseSqlite(_config.GetConnectionString("DefaultConnection_Sqlite")));

            }
            else
            {
                services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                _config.GetConnectionString("IdentityDefaultConnection"), providerOptions => providerOptions.EnableRetryOnFailure()));

                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                _config.GetConnectionString("DefaultConnection"), providerOptions => providerOptions.EnableRetryOnFailure()));

                services.AddDbContext<WebDbContext>(options =>
                options.UseSqlServer(
                    _config.GetConnectionString("WebDefaultConnection"), providerOptions => providerOptions.EnableRetryOnFailure()));

            }
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
                app.UseSwaggerUI(options =>
                {
                    foreach (var desc in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
                            desc.GroupName.ToUpperInvariant());
                    options.RoutePrefix = "";
                });
            }

            dbInitializer.Initialize();

            //app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();   //你在哪

            app.UseAuthentication();   //认证，你是谁
            app.UseAuthorization();     //授权，可以干什么

            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("https://localhost:4200"));

            app.UseDefaultFiles();
            app.UseStaticFiles();       //wwwroot，用来存储angular文件
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")), 
                RequestPath = "/content"
            });         //content用来存储如图片等

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");     //
            });
        }
    }
}
