
namespace QuickFix
{
    /// <summary>
    /// File log implementation
    /// </summary>
    internal class CompositeSessionLog : ISessionLog
    {
        private ISessionLog[] _sessionLogs;

        private bool _disposed = false;

        public CompositeSessionLog(ISessionLog[] sessionLogs)
        {
            _sessionLogs = sessionLogs;
        }

        public void Clear()
        {
            DisposedCheck();
            foreach (var log in _sessionLogs)
                log.Clear();
        }

        public void OnIncoming(string msg)
        {
            DisposedCheck();
            foreach (var log in _sessionLogs)
                log.OnIncoming(msg);
        }

        public void OnOutgoing(string msg)
        {
            DisposedCheck();
            foreach (var log in _sessionLogs)
                log.OnOutgoing(msg);
        }

        public void OnEvent(string s)
        {
            DisposedCheck();
            foreach (var log in _sessionLogs)
                log.OnEvent(s);
        }

        public void Dispose()
        {
            _disposed = true;
            foreach (var log in _sessionLogs)
                log.Dispose();
        }

        private void DisposedCheck()
        {
            if (_disposed)
                throw new System.ObjectDisposedException(this.GetType().Name);
        }
    }
}
