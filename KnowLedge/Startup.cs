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
using Myn.Core.AppSettingManager;
using System.IO;

namespace KnowLedge
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettingConfig.Configure(configuration);
        }

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
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; //���ص�json ��ʽ����
                })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddSession();
            //services.AddResponseCaching();//ʹ���м������ҳ�� �����ڹ�������ʽ���棬���Բ���view��action


            services.AddTransient<ITest, Test>()
                    .AddTransient<Testbll>()
                    .AddTransient<QuestionBusiness>()
                    .AddTransient<IQuestionRepository, QuestionRepository>()
                    .AddTransient<AnswerBusiness>()
                    .AddTransient<IAnswerRepository, AnswerRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// ����ܵ�����������http�Ĵ���
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ContactMiddleware>(); //�м��ע��


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            //wwwroot�ļ�ʹ��
            app.UseStaticFiles();
            //new StaticFileOptions(){FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))});

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