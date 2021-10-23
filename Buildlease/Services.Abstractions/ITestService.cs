using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ITestService
    {
        string DoTest(string name);
        Task<string> DoTest(string name, CancellationToken cancellationToken = default);
    }
}
