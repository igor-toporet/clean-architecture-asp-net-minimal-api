using System.Threading.Tasks;

namespace WebApplication1.App;

public interface IUseCase<in TIn>
{
    Task Handle(TIn input);
}
