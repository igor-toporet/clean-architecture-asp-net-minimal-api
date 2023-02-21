using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.App;
using WebApplication1.App.Web;

namespace WebApplication1;

public static class Bootstrap
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
     services
         .AddHttpContextAccessor()
            .AddTransient<IGreeter, PoliteGreeter>()
            // .AddTransient<IUseCase<PersonToGreet>, GreetUseCase>()
            .AddTransient<IGreetUseCase, GreetUseCase>()
            .AddTransient<IPresenter<Greeting>, GreetingPresenterHttp>()
            ;


        // var useCaseAssembly = typeof(IUseCase<>).Assembly;
        //
        // var registrations = (
        //     // from type in repositoryAssembly.GetTypes()
        //     from type in useCaseAssembly.GetExportedTypes()
        //     //where type.Namespace.StartsWith("MyComp.MyProd.DAL")
        //     from service in type.GetInterfaces()
        //     // where service.GetGenericTypeDefinition()==typ
        //     select new { service, implementation = type }
        // ).ToArray();
        //
        // foreach (var reg in registrations)
        // {
        //     services.AddTransient(reg.service, reg.implementation);
        // }

        return services;
    }
}
