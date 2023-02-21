using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using WebApplication1;
using WebApplication1.App;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();

var app = builder.Build();

app.AddGreetingEndpointGet();

app.Run();

public static class Endpoints
{
    public static void AddGreetingEndpointGet(
        this IEndpointRouteBuilder endpoints
    ) =>
        endpoints.MapGet("/greet/{name}", GetGreeting);

    private static async Task GetGreeting(
        string name,
        IGreetUseCase useCase
    )
    {
        var input = new PersonToGreet(name);
        await useCase.Handle(input);
    }
}