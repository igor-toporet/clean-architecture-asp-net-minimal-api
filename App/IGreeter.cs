using System.Threading.Tasks;

namespace WebApplication1.App;

internal interface IGreeter
{
    Task<string> Greet(string name);
}
