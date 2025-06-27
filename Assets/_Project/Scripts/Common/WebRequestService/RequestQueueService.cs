using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Common.WebRequestService;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RequestQueueService : IRequestService
{
    private Queue<RequestWrapper> requestQueue = new Queue<RequestWrapper>();
    private bool isProcessing = false;
    private RequestWrapper currentRequest;

    public void AddRequest(RequestWrapper request)
    {
        requestQueue.Enqueue(request);
        ProcessNext();
    }

    public void RemoveRequest(RequestWrapper targetRequest)
    {
        requestQueue = new Queue<RequestWrapper>(requestQueue.Where(x => x != targetRequest));
    }

    public void CancelCurrentRequest(RequestWrapper targetRequest)
    {
        Debug.Log(targetRequest);
        if (currentRequest != null && targetRequest == currentRequest)
        {
            currentRequest.DisposeToken();
            currentRequest = null;
        }
        isProcessing = false;
    }

    private void ProcessNext()
    {
        if (isProcessing || requestQueue.Count == 0) return;

        isProcessing = true;
        var requestFunc = requestQueue.Dequeue();
        currentRequest = requestFunc;
        ExecuteRequest(requestFunc);
    }
    
    private async void ExecuteRequest(RequestWrapper request)
    {
        await UniTask.RunOnThreadPool(() => request.StartRequest());
        isProcessing = false;
        ProcessNext();
    }
}