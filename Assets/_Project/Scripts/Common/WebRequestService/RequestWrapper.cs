using System.Threading;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Common.WebRequestService
{
    public class RequestWrapper
    {
        private UniTask _request;
        
        public CancellationTokenSource Cts { get; private set; } = new CancellationTokenSource();
        
        public void Init(UniTask request)
        {
            _request = request;
        }

        public async void StartRequest()
        {
            if (Cts != null && !Cts.IsCancellationRequested)
                Cts = new CancellationTokenSource();
            
            await _request;
        }

        public void DisposeToken()
        {
            Cts.Cancel();
            Cts.Dispose();
        }
    }
}