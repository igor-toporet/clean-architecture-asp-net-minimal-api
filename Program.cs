using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using WebApplication1;
using WebApplication1.App;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();

var app = builder.Build();

app.AddGreetingEndpointGet();

app.Run();

public static class Endpoints
{
    public static void AddGreetingEndpointGet(this WebApplication app) =>
        app.MapGet("/greet/{name}", Handler);

    private static async Task Handler(
        string name,
        IGreetUseCase useCase
    )
    {
        var input = new PersonToGreet(name);
        await useCase.Handle(input);
    }
}