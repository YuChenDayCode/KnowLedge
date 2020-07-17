using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utility.Filter;
using Core.Utility.MiddleWare;
using Know.Business;
using Know.IRepository;
using Know.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KnowLedge
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// ����������ϵ
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option =>
            {
                option.Filters.Add<CustomExceptionFilterAttribute>();//ȫ��ע�������
            });




            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSession();
            services.AddResponseCaching();//ʹ���м������ҳ�� �����ڹ�������ʽ���棬���Բ���view��action



            services.AddTransient<ITest, Test>();
            services.AddTransient<Testbll>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// ����ܵ�����������http�Ĵ���
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region �м��ģ��
            /* app.Use(next =>
            {
                return new RequestDelegate(
                    async context =>
                    {
                        await context.Response.WriteAsync("1 start; ");
                       
                        await context.Response.WriteAsync("1 end; ");
                        await next.Invoke(context);
                    });
            });
            app.Use(next =>
            {
                return new RequestDelegate(
                    async context =>
                    {
                        await context.Response.WriteAsync("2 start; ");
                       
                        await context.Response.WriteAsync("2 end; ");
                        await next.Invoke(context);
                    });
            });
            app.Use(next =>
            {
                return new RequestDelegate(
                    async context =>
                    {
                        await context.Response.WriteAsync("3 start; ");
                        await context.Response.WriteAsync("3 end; ");
                    });
            });


            app.Use(next =>
            {
                return async c => { await c.Response.WriteAsync("Hello World!"); };
            });//�м���÷�*/
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMiddleware<ContactProMiddleWare>(); //�м��ע��

            app.UseStaticFiles(); //wwwroot�ļ�ʹ��
            app.UseRouting();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{Action=Index}/{id?}"
                    );
            });

        }
    }
}
