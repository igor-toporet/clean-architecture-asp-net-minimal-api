using System.Threading.Tasks;

namespace WebApplication1.App;

internal class PoliteGreeter : IGreeter
{
    public async Task<string>  Greet(string name)
    {
        await Task.Delay(100);

        return $"Hello, {name}! How are you?";
    }
}
