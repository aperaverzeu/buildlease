using Contracts.Requests;
using Services.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class TestService : ITestService
    {
        public TestService() { }

        public string DoTest(string name)
        {
            Thread.Sleep(1000);
            return $"Hi there, {name}!";
        }

        public async Task<string> DoTest(string name, CancellationToken cancellationToken = default)
        {
            await Task.Delay(5000, cancellationToken);
            return $"Thanks for yout time, {name}.";
        }

        public string DoRequestTest(TestRequest request)
        {
            return $"Well done, {request.Name}!";
        }
    }
}
