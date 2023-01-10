using Microsoft.AspNetCore.Http;

namespace WebApplication1.App.Web;

internal class GreetingPresenterHttp: HttpPresenterBase<Greeting>
{
    public GreetingPresenterHttp(
        IHttpContextAccessor httpContextAccessor
    ) : base(httpContextAccessor)
    {
    }

    protected override IResult MapToResult(Greeting output) => 
        output.Text == default
            ? TypedResults.BadRequest("Dunno whom to greet 🤷‍♂")
            : TypedResults.Ok(output.Text);
}
