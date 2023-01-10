using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.App.Web;

internal abstract class HttpPresenterBase< TOut>:IPresenter<TOut>
{
    private readonly HttpContext _httpContext;

    protected HttpPresenterBase(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }

    public async Task Present(TOut output)
    {
        await MapToResult(output).ExecuteAsync(_httpContext);
    }

    protected abstract IResult MapToResult(TOut output);
}
