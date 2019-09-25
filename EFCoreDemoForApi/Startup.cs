using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace EFCoreDemoForApi
{
//处理项目在生成时报错"Visual Studio container tools require Docker to be running"
//最初win10上安装docker,项目启用docker支持,后来docker相关的操作都放到liunx服务中了,把本地的docker环境删掉了,再后来重新生成项目就报VS需要Docker启动....
//解决方案:删掉项目中 Microsoft.VisualStudio.Azure.Containers.Tools.Targets 的引用
/// <summary>
/// 
/// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(g=> {
                g.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "version 1",
                    Title = "EFCoreDemoForApi接口文档",
                    Description = "RESTful API for TwBusManagement",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "iimadao", Email = "iimadao@qq.com", Url = "" }
                });
                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "EFCoreDemoForApi.xml");
                g.IncludeXmlComments(xmlPath);

                //  c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<SchoolDbContext>(option =>
                option.UseMySql("server=39.104.19.32;port=4406;user id=root;password=123123;database=school_ddd_test;pooling=True;minpoolsize=1;maxpoolsize=10;connectiontimeout=180;")
            );
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFCoreDemoForApi API V1");
                c.ShowExtensions();
            });

            app.UseMvc();
        }
    }
}
