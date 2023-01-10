using System.Threading.Tasks;

namespace WebApplication1.App;

internal interface IPresenter<in TOut>
{
    Task Present(TOut output);
}
