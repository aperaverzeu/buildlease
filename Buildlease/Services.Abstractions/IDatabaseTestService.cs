using Contracts.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IDatabaseTestService
    {
        void RestartDatabase();
        void DoTest();
    }
}
