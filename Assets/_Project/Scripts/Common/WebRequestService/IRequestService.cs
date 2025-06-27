namespace _Project.Scripts.Common.WebRequestService
{
    public interface IRequestService
    {
        public void AddRequest(RequestWrapper request);

        public void RemoveRequest(RequestWrapper targetRequest);

        public void CancelCurrentRequest(RequestWrapper targetRequest);
    }
}