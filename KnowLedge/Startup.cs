using Core.Core;
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
        public IConfiguration _iConfiguration { get; }
        public Startup(IConfiguration configuration)
        {
            _iConfiguration = configuration;
            AppSettingConfig.Configure(configuration);
        }

        /// 配置依赖关系
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option =>
            {
                option.Filters.Add<CustomExceptionFilterAttribute>();//全局注册过滤器
                option.Filters.Add<CustomActionFilterAttribute>();
             });

            #region 注册配置文件服务
            services.Configure<AppSetting>(_iConfiguration); //注册配置文件服务
            //var config = new ConfigurationBuilder().AddJsonFile("jsonwnejian").Build(); //自定义json文件读取
            //services.Configure<jsonwenjian>(_iConfiguration); 
            #endregion


            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; //返回的默认的json 格式设置 如果自己重写了 这里就不生效了
                }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();//MVC默认模板的使用
            //services.AddSession();
            //services.AddResponseCaching();//使用中间件缓存页面 区别于过滤器方式缓存，可以不过view与action


            services.AddTransient<ITest, Test>()
                    .AddTransient<Testbll>()
                    .AddTransient<QuestionBusiness>()
                    .AddTransient<IQuestionRepository, QuestionRepository>()
                    .AddTransient<AnswerBusiness>()
                    .AddTransient<IAnswerRepository, AnswerRepository>()
                    .AddTransient<CommentBusiness>()
                    .AddTransient<ICommentRepository, CommentRepository>();

        }

        /// <summary>
        /// 请求管道：配置请求http的处理
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="options">配置文件注入</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<AppSetting> options)
        {
            //app.UseMiddleware<ContactMiddleware>(); //中间件注册
                                                    //options.Value.mysqlconfigPath
                                    
            #region MyRegion
            //env.IsProduction();//开发环境 根据约定会去执行ConfigureProServices方法 \Properties\launchSettings.json 中有环境变量配置 `ASPNETCORE_ENVIRONMENT`
            // env.IsEnvironment() 
            #endregion


            if (env.IsDevelopment())
            {
                // 开发人员异常页面中间件
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            //wwwroot文件使用
            app.UseStaticFiles();
            //new StaticFileOptions(){FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))});

            //使用路由
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
#region 中间件模拟
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

 });//中间件用法
 app.Use(next =>
 {
     return new RequestDelegate(async context => { await context.Response.WriteAsync("12 23!"); });

 });//中间件用法*/
#endregion