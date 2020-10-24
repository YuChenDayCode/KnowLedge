using Core.Core;
using Core.Data.MyFreeSql;
using Core.Utility.Filter;
using Core.Utility.MiddleWare;
using Know.Business;
using Know.Business.Business;
using Know.IRepository.IRepository;
using Know.Repository;
using Know.Repository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.IO;

namespace KnowLedge
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //AppSettingConfig.Configure(configuration);
        }

        /// ����������ϵ
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option =>
            {
                option.Filters.Add<CustomExceptionFilterAttribute>();//ȫ��ע�������
                option.Filters.Add<CustomActionFilterAttribute>();
             });



            #region ע�������ļ�����
            //var config = new ConfigurationBuilder().AddJsonFile("json.json").Build();
            #endregion


            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; //���ص�Ĭ�ϵ�json ��ʽ���� ����Լ���д�� ����Ͳ���Ч��
                }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();//MVCĬ��ģ���ʹ��
            //services.AddSession();
            //services.AddResponseCaching();//ʹ���м������ҳ�� �����ڹ�������ʽ���棬���Բ���view��action

            #region FreeSql
            //var aa = services.Configure<FreeSqlConfig>(_iConfiguration); aa[""]
            var freeSql = Configuration.GetSection("FreeSqlConfig").Get<FreeSqlConfig>();
            services.AddServiceFreeSql(freeSql);
            #endregion
        }

        /// <summary>
        /// ����ܵ�����������http�Ĵ���
        /// </summary>
        /// <param name="app"></param>45
        /// <param name="env"></param>
        /// <param name="options">�����ļ�ע��</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<AppSetting> options)
        {
            //app.UseMiddleware<ContactMiddleware>(); //�м��ע��
            //options.Value.mysqlconfigPath
                                    
            #region MyRegion
            //env.IsProduction();//�������� ����Լ����ȥִ��ConfigureProServices���� \Properties\launchSettings.json ���л����������� `ASPNETCORE_ENVIRONMENT`
            // env.IsEnvironment() 
            #endregion


            if (env.IsDevelopment())
            {
                // ������Ա�쳣ҳ���м��
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            //wwwroot�ļ�ʹ��
            app.UseStaticFiles();
            //new StaticFileOptions(){FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))});

            //ʹ��·��
            app.UseRouting()
            .UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{Action=Index}/{id?}"
                    );
            });

        }
    }
}
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
*/

/* app.Use(next =>
 {
     return new RequestDelegate( async context => { await context.Response.WriteAsync("Hello World!"); await next.Invoke(context); });

 });//�м���÷�
 app.Use(next =>
 {
     return new RequestDelegate(async context => { await context.Response.WriteAsync("12 23!"); });

 });//�м���÷�*/
#endregion