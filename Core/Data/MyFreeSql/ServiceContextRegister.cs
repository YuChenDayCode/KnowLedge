using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Core.Data.MyFreeSql
{
    public static class ServiceContextRegister
    {
        public static IServiceCollection AddServiceFreeSql(this IServiceCollection services, FreeSqlConfig _freeSqlConfig)
        {
            var fsBuilder = new FreeSqlBuilder()
                .UseConnectionString(_freeSqlConfig.DataType, _freeSqlConfig.MasterConnectStr)
                .UseLazyLoading(false)
                .UseMonitorCommand(exe =>
                {
                    Trace.WriteLine(exe.CommandText);
                });
            if (_freeSqlConfig.SlaveConnects?.Count > 0)//从库
            {
                fsBuilder.UseSlave(_freeSqlConfig.SlaveConnects.Select(s => s.ConnectionString).ToArray());
            }

            var fs = fsBuilder.Build();
            fs.SetDbContextOptions(option => option.EnableAddOrUpdateNavigateList = false);
            services.AddSingleton(fs);

            var RepositoryjAssembly = Assembly.Load("Know.Repository").GetTypes().Where(t => t.Name.EndsWith("Repository", StringComparison.InvariantCultureIgnoreCase) && t.IsClass && !t.IsAbstract && !t.IsGenericType).ToList();
            RepositoryjAssembly.ForEach(f =>
            {
                foreach (var interf in f.GetTypeInfo().ImplementedInterfaces.Where(t => t.IsPublic && t != typeof(IDisposable)))
                {
                    services.Add(new ServiceDescriptor(interf, f, ServiceLifetime.Scoped));
                }
            });

            var BusinessAssembly = Assembly.Load("Know.Business").GetTypes().Where(t => t.Name.EndsWith("Business", StringComparison.InvariantCultureIgnoreCase) && t.IsClass && !t.IsAbstract && !t.IsGenericType).ToList();
            BusinessAssembly.ForEach(f =>
            {
                services.AddScoped(f);
            });


            //Assembly[] assemblies = Assembly.GetExecutingAssembly();//.SelectMany(x => x.GetExportedTypes().Where(y => y.IsClass && !y.IsAbstract && !y.IsGenericType && !y.IsNested));
            //services.LoadAssemblys(Assembly.GetExecutingAssembly())
            //  .Where(x => x.Name.EndsWith("Repository", StringComparison.CurrentCultureIgnoreCase))
            //  .Registers(ServiceLifetime.Scoped);
            return services;
        }
    }
}
