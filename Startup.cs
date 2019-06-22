using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PPChat.Models;
using PPChat.Services;
using System;

namespace PPChat {
    public class Startup {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<PPChatDatabaseSettings>(
                Configuration.GetSection(nameof(PPChatDatabaseSettings)));

            services.AddSingleton<IPPChatDatabaseSettings>(
                sp => sp.GetRequiredService<IOptions<PPChatDatabaseSettings>>().Value);

            //services.AddScoped<UserService>();
            services.AddSingleton<UserService>();


            services.Configure<PPChatSessionSettings>(
                Configuration.GetSection(nameof(PPChatSessionSettings)));

            services.AddSingleton<IPPChatSessionSettings>(
                sp => sp.GetRequiredService<IOptions<PPChatSessionSettings>>().Value);

            services.AddSession(options =>
            {
                var conf = Configuration.GetSection(nameof(PPChatSessionSettings));
                options.Cookie.HttpOnly = Convert.ToBoolean(conf.GetValue<string>("HttpOnly"));
                options.IdleTimeout = TimeSpan.FromSeconds(conf.GetValue<double>("IdleTimeout"));
                options.Cookie.IsEssential = Convert.ToBoolean(conf.GetValue<string>("IsEssential"));
                options.Cookie.Name = conf.GetValue<string>("Name");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors(o => o.AddPolicy("CorsPolicy", options =>
            {
                options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseSpaStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
