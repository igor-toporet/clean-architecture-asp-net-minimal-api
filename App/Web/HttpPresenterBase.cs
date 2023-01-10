using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.App.Web;

internal abstract class HttpPresenterBase<TOut> : IPresenter<TOut>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    protected HttpPresenterBase(IHttpContextAccessor httpContextAccessor)
    {
        //
        // See https://learn.microsoft.com/en-us/aspnet/core/fundamentals/use-http-context?view=aspnetcore-7.0#httpcontext-isnt-thread-safe
        //   - Don't capture IHttpContextAccessor.HttpContext in a constructor.
        //
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Present(TOut output)
    {
        var httpContext = _httpContextAccessor.HttpContext!;

        await MapToResult(output).ExecuteAsync(httpContext);
    }

    protected abstract IResult MapToResult(TOut output);
}
