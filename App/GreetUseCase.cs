using System.Threading.Tasks;

namespace WebApplication1.App;

internal class GreetUseCase : IGreetUseCase
{
    private readonly IGreeter _greeter;
    private readonly IPresenter<Greeting> _presenter;

    public GreetUseCase(
        IGreeter greeter,
        IPresenter<Greeting> presenter
    )
    {
        _greeter = greeter;
        _presenter = presenter;
    }

    public async Task Handle(PersonToGreet personToGreet)
    {
        var name = personToGreet.Name;
        var greeting = await _greeter.Greet(name);

        var output = new Greeting(greeting);

        await _presenter.Present(output);
    }
}
