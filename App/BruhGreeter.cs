using System.Threading.Tasks;

namespace WebApplication1.App;

internal class BruhGreeter : IGreeter
{
    public async Task<string>  Greet(string name)
    {
        await Task.Delay(200);
        return $"Yo, {name}! Sup, bruh?";
    }
}
